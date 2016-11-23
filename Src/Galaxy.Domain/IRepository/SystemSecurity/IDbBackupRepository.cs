/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data;
using Galaxy.Entity.SystemSecurity;

namespace Galaxy.Domain.IRepository.SystemSecurity
{
    public interface IDbBackupRepository : IRepositoryBase<DbBackupEntity>
    {
        void DeleteForm(string keyValue);
        void ExecuteDbBackup(DbBackupEntity dbBackupEntity);
    }
}
