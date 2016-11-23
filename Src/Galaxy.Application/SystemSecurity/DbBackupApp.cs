/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Code;
using Galaxy.Entity.SystemSecurity;
using Galaxy.Domain.IRepository.SystemSecurity;
using Galaxy.Repository.SystemSecurity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Galaxy.Application.SystemSecurity
{
    public class DbBackupApp
    {
        private IDbBackupRepository service = new DbBackupRepository();

        public List<DbBackupEntity> GetList(string queryJson)
        {
            var expression = LinqExt.True<DbBackupEntity>();
            var queryParam = queryJson.ToObject();
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "DbName":  
                        expression = expression.And(t => t.DbName.Contains(keyword));
                        break;
                    case "FileName":
                        expression = expression.And(t => t.FileName.Contains(keyword));
                        break;
                }
            }
            return service.IQueryable(expression).OrderByDescending(t => t.BackupTime).ToList();
        }

        public DbBackupEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteForm(keyValue);
        }
        public void SubmitForm(DbBackupEntity dbBackupEntity)
        {
            dbBackupEntity.Id = Common.GuId();
            dbBackupEntity.EnabledMark = true;
            dbBackupEntity.BackupTime = DateTime.Now;
            service.ExecuteDbBackup(dbBackupEntity);
        }
    }
}
