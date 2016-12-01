/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System.Threading.Tasks;
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemManage;

namespace Galaxy.Repository.Interface.SystemManage
{
    public interface IUserRepository : IBaseRepository<User>
    {
        //Task DeleteAsync(string keyValue);
        //Task UpdateAsync(User userEntity, UserLogOn userLogOnEntity);
        //Task InsertAsync(User userEntity, UserLogOn userLogOnEntity);
    }
}
