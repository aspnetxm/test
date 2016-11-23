/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace Galaxy.Mapping.SystemManage
{
    public class ItemsDetailMap : EntityTypeConfiguration<ItemsDetailEntity>
    {
        public ItemsDetailMap()
        {
            this.ToTable("Sys_ItemsDetail");
            this.HasKey(t => t.Id);
        }
    }
}
