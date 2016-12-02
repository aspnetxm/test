/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Repository.Infrastructure;
using Galaxy.Domain.Entity.SystemSecurity;

namespace Galaxy.Repository.Interface.SystemSecurity
{
    public interface IDbBackupRepository : IRepositoryBase<DbBackup>
    {
        void DeleteForm(string keyValue);
        void ExecuteDbBackup(DbBackup dbBackupEntity);
    }
}
