﻿/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;
using Galaxy.Entity.Infrastructure;

namespace Galaxy.Entity.SystemSecurity
{
    public class FilterIP : IEntity<FilterIP>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string Id { get; set; }
        public bool? Type { get; set; }
        public string StartIP { get; set; }
        public string EndIP { get; set; }
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
