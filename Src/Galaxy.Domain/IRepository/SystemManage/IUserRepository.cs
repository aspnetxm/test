/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemManage;

namespace Galaxy.IRepository.SystemManage
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        void Delete(string keyValue);
        void Update(User userEntity, UserLogOn userLogOnEntity);
        void Insert(User userEntity, UserLogOn userLogOnEntity);
    }
}
