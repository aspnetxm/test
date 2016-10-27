﻿/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Domain.Entity.SystemSecurity;
using System.Data.Entity.ModelConfiguration;

namespace Galaxy.Mapping.SystemSecurity
{
    public class DbBackupMap : EntityTypeConfiguration<DbBackupEntity>
    {
        public DbBackupMap()
        {
            this.ToTable("Sys_DbBackup");
            this.HasKey(t => t.Id);
        }
    }
}
