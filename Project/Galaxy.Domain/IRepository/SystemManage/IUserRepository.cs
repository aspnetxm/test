/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemManage;

namespace Galaxy.Domain.IRepository.SystemManage
{
    public interface IUserRepository : IRepositoryBase<UserEntity>
    {
        void DeleteForm(string keyValue);
        void SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue);
    }
}
