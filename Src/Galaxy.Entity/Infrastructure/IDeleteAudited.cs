﻿/*******************************************************************************
 * 作者：星星    
 * 描述： 
 * 修改记录： 
*********************************************************************************/
using System;

namespace Galaxy.Entity.Infrastructure
{
    public interface IDeleteAudited 
    {
        /// <summary>
        /// 逻辑删除标记
        /// </summary>
        bool? DeleteMark { get; set; }

        /// <summary>
        /// 删除实体的用户
        /// </summary>
        string DeleteUserId { get; set; }

        /// <summary>
        /// 删除实体时间
        /// </summary>
        DateTime? DeleteTime { get; set; } 
    }
}