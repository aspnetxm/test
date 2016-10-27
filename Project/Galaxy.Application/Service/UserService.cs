using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Code;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Domain.IRepository.SystemManage;
using Galaxy.Repository.SystemManage;

namespace Galaxy.Application.Service
{
    public class UserService : IUserService
    {
        private IUserRepository userService = new UserRepository();
        private IUserLogOnRepository userLogService = new UserLogOnRepository();

        public async Task<UserEntity> Login(string username, string password)
        {
            return await Task.Run(() =>
            {
                UserEntity userEntity = userService.FindEntity(t => t.Account == username);
                if (userEntity == null)
                {
                    throw new Exception("账户不存在，请重新输入");
                }
                if (userEntity.EnabledMark != true)
                {
                    throw new Exception("账户被系统锁定,请联系管理员");
                }

                UserLogOnEntity userLogOnEntity = userLogService.FindEntity(o => o.UserId == userEntity.Id);
                string dbPassword = Md5Encrypt.Md5(AES.Encrypt(password.ToLower(), userLogOnEntity.UserSecretkey).ToLower(), 32).ToLower();
                if (dbPassword != userLogOnEntity.UserPassword)
                {
                    throw new Exception("密码不正确，请重新输入");
                }

                DateTime lastVisitTime = DateTime.Now;
                int LogOnCount = userLogOnEntity.LogOnCount ?? +1;
                if (userLogOnEntity.LastVisitTime != null)
                {
                    userLogOnEntity.PreviousVisitTime = userLogOnEntity.LastVisitTime;
                }
                userLogOnEntity.LastVisitTime = lastVisitTime;
                userLogOnEntity.LogOnCount = LogOnCount;
                userLogService.Update(userLogOnEntity);
                return userEntity;
            });
        }
    }
}
