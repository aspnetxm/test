/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Code;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Domain.IRepository.SystemManage;
using Galaxy.Repository.SystemManage;

namespace Galaxy.Service.SystemManage
{
    public class UserLogOnApp
    {
        private IUserLogOnRepository service = new UserLogOnRepository();

        public UserLogOn GetForm(string keyValue)
        {
            return service.Get(keyValue);
        }
        public void UpdateForm(UserLogOn userLogOnEntity)
        {
            service.Update(userLogOnEntity);
        }
        public void RevisePassword(string userPassword,string keyValue)
        {
            UserLogOn userLogOnEntity = new UserLogOn();
            userLogOnEntity.Id = keyValue;
            userLogOnEntity.UserSecretkey = Md5Encrypt.Md5(Common.CreateNo(), 16).ToLower();
            userLogOnEntity.UserPassword = Md5Encrypt.Md5(AES.Encrypt(Md5Encrypt.Md5(userPassword, 32).ToLower(), userLogOnEntity.UserSecretkey).ToLower(), 32).ToLower();
            service.Update(userLogOnEntity);
        }
    }
}
