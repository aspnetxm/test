/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Domain.Entity.SystemSecurity;
using System.Data.Entity.ModelConfiguration;

namespace Galaxy.Mapping.SystemSecurity
{
    public class OprLogMap : EntityTypeConfiguration<OprLog>
    {
        public OprLogMap()
        {
            this.ToTable("Sys_OprLog");
            this.HasKey(t => t.Id);
        }
    }
}
