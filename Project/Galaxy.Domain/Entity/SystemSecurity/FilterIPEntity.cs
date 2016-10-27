/*******************************************************************************
 * 作者：星星    
 * 描述：过滤IP  
 * 修改记录： 
*********************************************************************************/
using System;

namespace Galaxy.Domain.Entity.SystemSecurity
{
    /// <summary>
    /// 过滤IP
    /// </summary>
    public class FilterIPEntity : IEntity<FilterIPEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string Id { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public bool? Type { get; set; }
        /// <summary>
        /// 开始IP
        /// </summary>
        public string StartIP { get; set; }
        /// <summary>
        /// 结束IP
        /// </summary>
        public string EndIP { get; set; }
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
