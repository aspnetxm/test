/*******************************************************************************
 * 作者：星星    
 * 描述：行政区域表
 * 修改记录： 
*********************************************************************************/
using System;

namespace Galaxy.Domain.Entity.SystemManage
{
    /// <summary>
    /// 行政区域表
    /// </summary>
    public class AreaEntity : IEntity<AreaEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string Id { get; set; }
        /// <summary>
        /// 父级
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 层次
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
        /// 简拼
        /// </summary>
        public string SimpleSpelling { get; set; }
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
