/*******************************************************************************
 * 作者：星星    
 * 描述：选项主表
 * 修改记录： 
*********************************************************************************/
using System;

namespace Galaxy.Domain.Entity.SystemManage
{
    /// <summary>
    /// 选项主表
    /// </summary>
    public class ItemsEntity : IEntity<ItemsEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string Id { get; set; }
        /// <summary>
        /// 父级
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string EnCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 树型
        /// </summary>
        public bool? IsTree { get; set; }
        /// <summary>
        /// 层次
        /// </summary>
        public int? Layers { get; set; }
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
