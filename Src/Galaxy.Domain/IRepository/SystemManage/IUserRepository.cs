/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data;
using Galaxy.Entity.SystemManage;

namespace Galaxy.Domain.IRepository.SystemManage
{
    public interface IUserRepository : IRepositoryBase<UserEntity>
    {
        void Delete(string keyValue);
        void Update(UserEntity userEntity, UserLogOnEntity userLogOnEntity);
        void Insert(UserEntity userEntity, UserLogOnEntity userLogOnEntity);
    }
}
