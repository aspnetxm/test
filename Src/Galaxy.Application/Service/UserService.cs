using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Code;
using Galaxy.Entity.SystemManage;
using Galaxy.Domain.IRepository.SystemManage;
using Galaxy.Repository.SystemManage;

namespace Galaxy.Application.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _userService;// = new UserRepository();
        private IUserLogOnRepository _userLogService;//= new UserLogOnRepository();

        public UserService(IUserRepository userService, IUserLogOnRepository userLogService)
        {
            _userService = userService;
            _userLogService = userLogService;
        }

        public async Task<R<UserEntity>> Login(string username, string password)
        {
            return await Task.Run(() =>
            {
                UserEntity userEntity = _userService.FindEntity(t => t.Account == username);
                if (userEntity == null)
                {
                    return R<UserEntity>.Error("账户不存在，请重新输入");
                }
                if (userEntity.EnabledMark != true)
                {
                    return R<UserEntity>.Error("账户被系统锁定,请联系管理员");
                }

                UserLogOnEntity userLogOnEntity = _userLogService.FindEntity(o => o.UserId == userEntity.Id);
                string dbPassword = Md5Encrypt.Md5(AES.Encrypt(password.ToLower(), userLogOnEntity.UserSecretkey).ToLower(), 32).ToLower();
                if (dbPassword != userLogOnEntity.UserPassword)
                {
                    return R<UserEntity>.Error("密码不正确，请重新输入");
                }

                DateTime lastVisitTime = DateTime.Now;
                int LogOnCount = userLogOnEntity.LogOnCount ?? +1;
                if (userLogOnEntity.LastVisitTime != null)
                {
                    userLogOnEntity.PreviousVisitTime = userLogOnEntity.LastVisitTime;
                }
                userLogOnEntity.LastVisitTime = lastVisitTime;
                userLogOnEntity.LogOnCount = LogOnCount;
                _userLogService.Update(userLogOnEntity);

                return R<UserEntity>.Success(userEntity);
            });
        }
    }
}
