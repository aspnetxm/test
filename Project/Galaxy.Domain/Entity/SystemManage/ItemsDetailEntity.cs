/*******************************************************************************
 * 作者：星星    
 * 描述：选项明细表  
 * 修改记录： 
*********************************************************************************/
using System;

namespace Galaxy.Domain.Entity.SystemManage
{
    /// <summary>
    /// 选项明细表
    /// </summary>
    public class ItemsDetailEntity : IEntity<ItemsDetailEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string Id { get; set; }
        /// <summary>
        /// 主表主键
        /// </summary>
        public string ItemId { get; set; }
        /// <summary>
        /// 父级
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 简拼
        /// </summary>
        public string SimpleSpelling { get; set; }
        /// <summary>
        /// 默认
        /// </summary>
        public bool? IsDefault { get; set; }
        public int? Layers { get; set; }
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
