﻿/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace Galaxy.Mapping.SystemManage
{
    public class AreaMap : EntityTypeConfiguration<Area>
    {
        public AreaMap()
        {
            this.ToTable("Area");
            this.HasKey(t => t.Id);
        }
    }
}
