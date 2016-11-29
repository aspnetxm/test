using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Galaxy.Data;
using Galaxy.Code;
using Galaxy.Domain.IRepository.SystemManage;
using Galaxy.Service.Interfaces;
using Galaxy.Domain.Dto;
using Galaxy.Domain.Entity.SystemManage;

namespace Galaxy.Service.SystemManage
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IUserLogOnRepository _logOnRepository;

        public UserService(IUserRepository userService, IUserLogOnRepository userLogService)
        {
            _userRepository = userService;
            _logOnRepository = userLogService;
        }

        public async Task<UserVerifyResult> Verification(string username, string password)
        {
            UserVerifyResult result = new UserVerifyResult { IsSuc = false };

            User user = await _userRepository.GetAsync(t => t.Account == username || t.Email == username);
            if (user == null)
            {
                result.Error = "账户不存在，请重新输入";
                return result;
            }
            if (user.EnabledMark != true)
            {
                result.Error = "账户被系统锁定,请联系管理员";
                return result;
            }

            UserLogOn userLogOnEntity = await _logOnRepository.GetAsync(o => o.UserId == user.Id);
            string dbPassword = Md5Encrypt.Md5(AES.Encrypt(password.ToLower(), userLogOnEntity.UserSecretkey).ToLower(), 32).ToLower();
            if (dbPassword != userLogOnEntity.UserPassword)
            {
                result.Error = "密码不正确，请重新输入";
                return result;
            }

            DateTime lastVisitTime = DateTime.Now;
            int LogOnCount = userLogOnEntity.LogOnCount ?? +1;
            if (userLogOnEntity.LastVisitTime != null)
            {
                userLogOnEntity.PreviousVisitTime = userLogOnEntity.LastVisitTime;
            }
            userLogOnEntity.LastVisitTime = lastVisitTime;
            userLogOnEntity.LogOnCount = LogOnCount;
            _logOnRepository.Update(userLogOnEntity);
            result.User = user;
            return result;
        }

        public async Task<List<User>> GetList(Pagination pagination, string keyword)
        {
            var expression = LinqExt.True<User>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.Account.Contains(keyword));
                expression = expression.Or(t => t.RealName.Contains(keyword));
                expression = expression.Or(t => t.MobilePhone.Contains(keyword));
            }
            expression = expression.And(t => t.Account != "admin");
            return await _userRepository.FindListAsync(expression, pagination);
        }

        public async Task<User> GetById(string keyValue)
        {
            return await _userRepository.GetAsync(keyValue);
        }

        public async Task DeleteById(string keyValue)
        {
            await _userRepository.DeleteAsync(keyValue);
        }

        public async Task SubmitForm(User userEntity, UserLogOn userLogOnEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                userEntity.Modify(keyValue);
            }
            else
            {
                userEntity.Create();
            }
            await _userRepository.UpdateAsync(userEntity, userLogOnEntity);

        }
    }
}