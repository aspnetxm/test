/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Repository.Infrastructure;
using Galaxy.Domain.Entity.SystemSecurity;
using Galaxy.Repository.Interface.SystemSecurity;
using Galaxy.Repository.Infrastructure.Data;

namespace Galaxy.Repository.SystemSecurity
{
    public class DbBackupRepository : RepositoryBase<DbBackup>, IDbBackupRepository
    {
        IUnitOfWork _unitOfWork;
        public DbBackupRepository(IUnitOfWork unitOfWork) : base(unitOfWork.DbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteForm(string keyValue)
        {
            var dbBackupEntity = Get(keyValue);
            if (dbBackupEntity != null)
            {
                //FileHelper.DeleteFile(dbBackupEntity.FilePath);
            }
            _unitOfWork.Delete<DbBackup>(dbBackupEntity);
        }
        public void ExecuteDbBackup(DbBackup dbBackupEntity)
        {
            DbHelper.ExecuteSqlCommand(string.Format("backup database {0} to disk ='{1}'", dbBackupEntity.DbName, dbBackupEntity.FilePath));
            //dbBackupEntity.FileSize = FileHelper.ToFileSize(FileHelper.GetFileSize(dbBackupEntity.FilePath));
            //dbBackupEntity.FilePath = "/Resource/DbBackup/" + dbBackupEntity.FileName;
            //this.Insert(dbBackupEntity);


        }
    }
}
