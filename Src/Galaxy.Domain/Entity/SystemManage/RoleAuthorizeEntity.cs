/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;

namespace Galaxy.Domain.Entity.SystemManage
{
    /// <summary>
    /// 角色授权表
    /// </summary>
    public class RoleAuthorizeEntity : IEntity<RoleAuthorizeEntity>, ICreationAudited
    {
        public string Id { get; set; }
        public int? ItemType { get; set; }
        public string ItemId { get; set; }
        public int? ObjectType { get; set; }
        public string ObjectId { get; set; }
        public int? SortCode { get; set; }


        public DateTime? CreatorTime { get; set; }
        public string CreatorUserId { get; set; }
    }
}
