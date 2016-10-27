/*******************************************************************************
 * 作者：星星    
 * 描述：模块按钮  
 * 修改记录： 
*********************************************************************************/
using System;

namespace Galaxy.Domain.Entity.SystemManage
{
    /// <summary>
    /// 模块按钮
    /// </summary>
    public class ModuleButtonEntity : IEntity<ModuleButtonEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string Id { get; set; }
        /// <summary>
        /// 模块主键
        /// </summary>
        public string ModuleId { get; set; }
        /// <summary>
        /// 父级
        /// </summary>
        public string ParentId { get; set; }
        public int? Layers { get; set; }
        public string EnCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public int? Location { get; set; }
        /// <summary>
        /// 事件
        /// </summary>
        public string JsEvent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UrlAddress { get; set; }
        /// <summary>
        /// 分开线
        /// </summary>
        public bool? Split { get; set; }
        /// <summary>
        /// 公共
        /// </summary>
        public bool? IsPublic { get; set; }
        public bool? AllowEdit { get; set; }
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
