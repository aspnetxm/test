/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Entity.SystemSecurity;
using System.Data.Entity.ModelConfiguration;

namespace Galaxy.Mapping.SystemSecurity
{
    public class FilterIPMap : EntityTypeConfiguration<FilterIP>
    {
        public FilterIPMap()
        {
            this.ToTable("FilterIP");
            this.HasKey(t => t.Id);
        }
    }
}
