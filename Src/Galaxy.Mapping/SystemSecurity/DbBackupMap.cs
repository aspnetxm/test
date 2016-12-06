/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Entity.SystemSecurity;
using System.Data.Entity.ModelConfiguration;

namespace Galaxy.Mapping.SystemSecurity
{
    public class DbBackupMap : EntityTypeConfiguration<DbBackup>
    {
        public DbBackupMap()
        {
            this.ToTable("DbBackup");
            this.HasKey(t => t.Id);
        }
    }
}
