﻿/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace Galaxy.Mapping.SystemManage
{
    public class ModuleButtonMap : EntityTypeConfiguration<ModuleButton>
    {
        public ModuleButtonMap()
        {
            this.ToTable("ModuleButton");
            this.HasKey(t => t.Id);
        }
    }
}
