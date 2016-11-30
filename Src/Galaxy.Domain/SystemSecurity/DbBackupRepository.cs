/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data;
using Galaxy.Data.Extensions;
using Galaxy.Domain.Entity.SystemSecurity;
using Galaxy.Domain.IRepository.SystemSecurity;

namespace Galaxy.Repository.SystemSecurity
{
    public class DbBackupRepository : BaseRepository<DbBackup>, IDbBackupRepository
    {
        IDbContext _dbContext;
        public DbBackupRepository(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteForm(string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                var dbBackupEntity = db.FindEntity<DbBackup>(keyValue);
                if (dbBackupEntity != null)
                {
                    //FileHelper.DeleteFile(dbBackupEntity.FilePath);
                }
                db.Delete<DbBackup>(dbBackupEntity);
                db.Commit();
            }
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
