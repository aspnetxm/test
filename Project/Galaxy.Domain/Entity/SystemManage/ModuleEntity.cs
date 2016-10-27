/*******************************************************************************
 * 作者：星星    
 * 描述：系统模块  
 * 修改记录： 
*********************************************************************************/
using System;

namespace Galaxy.Domain.Entity.SystemManage
{
    /// <summary>
    /// 系统模块
    /// </summary>
    public class ModuleEntity : IEntity<ModuleEntity>, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        public string Id { get; set; }
        /// <summary>
        /// 父级
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Layers { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string EnCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 连接
        /// </summary>
        public string UrlAddress { get; set; }
        /// <summary>
        /// 目标
        /// </summary>
        public string Target { get; set; }
        /// <summary>
        /// 菜单
        /// </summary>
        public bool? IsMenu { get; set; }
        /// <summary>
        /// 展开
        /// </summary>
        public bool? IsExpand { get; set; }
        /// <summary>
        /// 公共
        /// </summary>
        public bool? IsPublic { get; set; }
        /// <summary>
        /// 允许编辑
        /// </summary>
        public bool? AllowEdit { get; set; }
        /// <summary>
        /// 允许删除
        /// </summary>
        public bool? AllowDelete { get; set; }
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
