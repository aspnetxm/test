/*******************************************************************************
 * 作者：星星    Galaxy.Entity.SystemManage;
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Entity.SystemSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Service.SystemManage
{
    public interface IDbBackupService
    {
        List<DbBackup> GetList(string queryJson);

        DbBackup GetForm(string keyValue);

        Task DeleteForm(string keyValue);

        Task SubmitForm(DbBackup dbBackupEntity);

    }
}
