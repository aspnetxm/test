/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;
using System.Collections.Generic;
using Galaxy.Code;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Domain.IRepository.SystemManage;
using Galaxy.Repository.SystemManage;
using Galaxy.Data;

namespace Galaxy.Application.SystemManage
{
    public class UserApp
    {
        private IUserRepository service = new UserRepository();
        private UserLogOnApp userLogOnApp = new UserLogOnApp();

        public List<UserEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = LinqExt.True<UserEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.Account.Contains(keyword));
                expression = expression.Or(t => t.RealName.Contains(keyword));
                expression = expression.Or(t => t.MobilePhone.Contains(keyword));
            }
            expression = expression.And(t => t.Account != "admin");
            return service.FindList(expression, pagination);
        }
        public UserEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void DeleteForm(string keyValue)
        {
            service.DeleteForm(keyValue);
        }

        public void SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                userEntity.Modify(keyValue);
            }
            else
            {
                userEntity.Create();
            }
            service.SubmitForm(userEntity, userLogOnEntity, keyValue);
        }

        public void UpdateForm(UserEntity userEntity)
        {
            service.Update(userEntity);
        }

        /// <summary>
        /// 登录密码登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserEntity Login(string username, string password)
        {
            UserEntity userEntity = service.FindEntity(t => t.Account == username);
            if (userEntity == null)
            {
                throw new Exception("账户不存在，请重新输入");
            }

            if (userEntity.EnabledMark != true)
            {
                throw new Exception("账户被系统锁定,请联系管理员");
            }

            UserLogOnEntity userLogOnEntity = userLogOnApp.GetForm(userEntity.Id);
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
            userLogOnApp.UpdateForm(userLogOnEntity);
            return userEntity;
        }
    }
}
