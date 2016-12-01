﻿/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemSecurity;

namespace Galaxy.Repository.Interface.SystemSecurity
{
    public interface IDbBackupRepository : IBaseRepository<DbBackup>
    {
        void DeleteForm(string keyValue);
        void ExecuteDbBackup(DbBackup dbBackupEntity);
    }
}
