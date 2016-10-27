/*******************************************************************************
 * 作者：星星    
 * 描述：角色表
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
        /// 编号
        /// </summary>
        public string EnCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 允许编辑
        /// </summary>
        public bool? AllowEdit { get; set; }
        /// <summary>
        /// 允许删除
        /// </summary>
        public bool? AllowDelete { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }
        /// <summary>
        /// 删除标志
        /// </summary>
        public bool? DeleteMark { get; set; }
        /// <summary>
        /// 有效标志
        /// </summary>
        public bool? EnabledMark { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }


        public DateTime? CreatorTime { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public string LastModifyUserId { get; set; }
        public DateTime? DeleteTime { get; set; }
        public string DeleteUserId { get; set; }
    }
}
