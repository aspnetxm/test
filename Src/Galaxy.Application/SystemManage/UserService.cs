using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Galaxy.Repository.Infrastructure;
using Galaxy.Utility;
using Galaxy.Repository.Interface.SystemManage;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.DTO.CommonModule;
using Galaxy.DTO.SystemManage;

namespace Galaxy.Service.SystemManage
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private IUserRepository _userRepository;
        private IUserLogOnRepository _logOnRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userService, IUserLogOnRepository userLogService)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userService;
            _logOnRepository = userLogService;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<UserVerifyDTO> Verification(string username, string password)
        {
            UserVerifyDTO result = new UserVerifyDTO { IsSuc = false };

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
            //_logOnRepository.Update(userLogOnEntity);
            await _unitOfWork.UpdateAsync<UserLogOn>(userLogOnEntity);
            await _unitOfWork.CommitAsync();
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
            _unitOfWork.BeginTransaction();
            await _unitOfWork.DeleteAsync<User>(o => o.Id == keyValue);
            await _unitOfWork.DeleteAsync<UserLogOn>(o => o.UserId == keyValue);
            await _unitOfWork.CommitAsync();
        }

        public async Task SubmitForm(User userEntity, UserLogOn userLogOnEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                userEntity.Modify(keyValue);
                _unitOfWork.BeginTransaction();
                await _unitOfWork.UpdateAsync<User>(userEntity);
                await _unitOfWork.UpdateAsync<UserLogOn>(userLogOnEntity);
            }
            else
            {
                userLogOnEntity.Id = userEntity.Id;
                userLogOnEntity.UserId = userEntity.Id;
                userLogOnEntity.UserSecretkey = Md5Encrypt.Md5(Common.CreateNo(), 16).ToLower();
                userLogOnEntity.UserPassword = Md5Encrypt.Md5(AES.Encrypt(Md5Encrypt.Md5(userLogOnEntity.UserPassword, 32).ToLower(), userLogOnEntity.UserSecretkey).ToLower(), 32).ToLower();

                _unitOfWork.BeginTransaction();
                await _unitOfWork.InsertAsync<User>(userEntity);
                await _unitOfWork.InsertAsync<UserLogOn>(userLogOnEntity);
            }

            await _unitOfWork.CommitAsync();
        }
    }
}