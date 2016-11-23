/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Entity.SystemSecurity;
using System.Data.Entity.ModelConfiguration;

namespace Galaxy.Mapping.SystemSecurity
{
    public class FilterIPMap : EntityTypeConfiguration<FilterIPEntity>
    {
        public FilterIPMap()
        {
            this.ToTable("Sys_FilterIP");
            this.HasKey(t => t.Id);
        }
    }
}
