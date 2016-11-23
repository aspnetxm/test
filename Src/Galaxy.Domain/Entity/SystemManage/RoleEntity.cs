/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;

namespace Galaxy.Domain.Entity.SystemManage
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class RoleEntity : IEntity<RoleEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string Id { get; set; }
        /// <summary>
        /// 组织主键
        /// </summary>
        public string OrganizeId { get; set; }
        /// <summary>
        /// 分类:1-角色 2-岗位
        /// </summary>
        public int? Category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EnCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? AllowEdit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? AllowDelete { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? SortCode { get; set; }
        public bool? DeleteMark { get; set; }
        public bool? EnabledMark { get; set; }
        public string Description { get; set; }


        public DateTime? CreatorTime { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public string LastModifyUserId { get; set; }
        public DateTime? DeleteTime { get; set; }
        public string DeleteUserId { get; set; }
    }
}
