/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Code;
using Galaxy.Entity.SystemManage;
using Galaxy.Domain.IRepository.SystemManage;
using Galaxy.Repository.SystemManage;

namespace Galaxy.Application.SystemManage
{
    public class UserLogOnApp
    {
        private IUserLogOnRepository service = new UserLogOnRepository();

        public UserLogOnEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void UpdateForm(UserLogOnEntity userLogOnEntity)
        {
            service.Update(userLogOnEntity);
        }
        public void RevisePassword(string userPassword,string keyValue)
        {
            UserLogOnEntity userLogOnEntity = new UserLogOnEntity();
            userLogOnEntity.Id = keyValue;
            userLogOnEntity.UserSecretkey = Md5Encrypt.Md5(Common.CreateNo(), 16).ToLower();
            userLogOnEntity.UserPassword = Md5Encrypt.Md5(AES.Encrypt(Md5Encrypt.Md5(userPassword, 32).ToLower(), userLogOnEntity.UserSecretkey).ToLower(), 32).ToLower();
            service.Update(userLogOnEntity);
        }
    }
}
