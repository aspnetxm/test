/*******************************************************************************
 * 作者：星星    Galaxy.Entity.SystemManage;
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Utility;
using Galaxy.Entity.SystemSecurity;
using Galaxy.Repository.Interface.SystemSecurity;
using Galaxy.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Service.SystemSecurity
{
    public class DbBackupService
    {
        private IUnitOfWork _unitOfWork;
        private IDbBackupRepository _service;

        public DbBackupService(IUnitOfWork unitOfWork, IDbBackupRepository service)
        {
            _unitOfWork = unitOfWork;
            _service = service;
        }


        public List<DbBackup> GetList(string queryJson)
        {
            var expression = LinqExt.True<DbBackup>();
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
            return _service.IQueryable(expression).OrderByDescending(t => t.BackupTime).ToList();
        }

        public DbBackup GetForm(string keyValue)
        {
            return _service.Get(keyValue);
        }
        public async Task DeleteForm(string keyValue)
        {
            var dbBackupEntity = await _service.GetAsync(keyValue);
            if (dbBackupEntity != null)
            {
                //FileHelper.DeleteFile(dbBackupEntity.FilePath);
            }
            await _unitOfWork.DeleteAsync<DbBackup>(dbBackupEntity);
            await _unitOfWork.CommitAsync();
        }

        public async Task SubmitForm(DbBackup dbBackupEntity)
        {
            _service.ExecuteDbBackup(dbBackupEntity);

            dbBackupEntity.Id = Common.GuId();
            dbBackupEntity.EnabledMark = true;
            dbBackupEntity.BackupTime = DateTime.Now;
            //dbBackupEntity.FileSize = FileHelper.ToFileSize(FileHelper.GetFileSize(dbBackupEntity.FilePath));
            dbBackupEntity.FilePath = "/Resource/DbBackup/" + dbBackupEntity.FileName;

            await _unitOfWork.InsertAsync(dbBackupEntity);
            await _unitOfWork.CommitAsync();
        }
    }
}
