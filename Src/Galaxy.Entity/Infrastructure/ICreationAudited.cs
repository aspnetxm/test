/*******************************************************************************
 * 作者：星星    
 * 描述： 
 * 修改记录： 
*********************************************************************************/
using System;

namespace Galaxy.Domain.Infrastructure
{
    public interface ICreationAudited
    {
        string Id { get; set; }
        /// <summary>
        /// 创建实体的用户
        /// </summary>
        string CreatorUserId { get; set; }
        /// <summary>
        /// 创建实体的时间
        /// </summary>
        DateTime? CreatorTime { get; set; }
    }
}