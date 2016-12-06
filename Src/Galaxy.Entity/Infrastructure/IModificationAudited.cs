/*******************************************************************************
 * 作者：星星    
 * 描述： 
 * 修改记录： 
*********************************************************************************/
using System;

namespace Galaxy.Entity.Infrastructure
{
    public interface IModificationAudited
    {
        string Id { get; set; }
        /// <summary>
        /// 修改实体的用户
        /// </summary>
        string LastModifyUserId { get; set; }
        /// <summary>
        /// 修改实体的时间
        /// </summary>
        DateTime? LastModifyTime { get; set; }
    }
}