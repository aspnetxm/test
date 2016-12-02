/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Code;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Repository.Interface.SystemManage;
using Galaxy.Repository.Infrastructure;

namespace Galaxy.Service.SystemManage
{
    public class UserLogOnServic: IUserLogOnServic
    {
        private IUserLogOnRepository _userLogOnRepository; 
        private IUnitOfWork _unitOfWork;

        public UserLogOnServic(IUnitOfWork unitOfWork, IUserLogOnRepository service)
        {
            _unitOfWork = unitOfWork;
            _userLogOnRepository = service;
        }

        public UserLogOn GetForm(string keyValue)
        {
            return _userLogOnRepository.Get(keyValue);
        }
        public void UpdateForm(UserLogOn userLogOnEntity)
        {
            _unitOfWork.Update(userLogOnEntity);
            _unitOfWork.Commit();
        }

        public void RevisePassword(string userPassword, string keyValue)
        {
            UserLogOn userLogOnEntity = new UserLogOn();
            userLogOnEntity.Id = keyValue;
            userLogOnEntity.UserSecretkey = Md5Encrypt.Md5(Common.CreateNo(), 16).ToLower();
            userLogOnEntity.UserPassword = Md5Encrypt.Md5(AES.Encrypt(Md5Encrypt.Md5(userPassword, 32).ToLower(), userLogOnEntity.UserSecretkey).ToLower(), 32).ToLower();
            _unitOfWork.Update(userLogOnEntity);
            _unitOfWork.Commit();
        }
    }
}
