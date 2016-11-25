/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;
using Galaxy.Domain.Infrastructure;

namespace Galaxy.Domain.Entity.SystemSecurity
{
    /// <summary>
    /// 日志
    /// </summary>
    public class OprLog : IEntity<OprLog>, ICreationAudited
    {
        public string Id { get; set; }
        public DateTime? Date { get; set; }
        public string Account { get; set; }
        public string NickName { get; set; }
        public string Type { get; set; }
        public string IPAddress { get; set; }
        public string IPAddressName { get; set; }
        public string ModuleId { get; set; }
        public string ModuleName { get; set; }
        public bool? Result { get; set; }
        public string Description { get; set; }


        public DateTime? CreatorTime { get; set; }
        public string CreatorUserId { get; set; }
    }
}
