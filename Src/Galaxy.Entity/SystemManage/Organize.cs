﻿/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;
using Galaxy.Entity.Infrastructure;

namespace Galaxy.Entity.SystemManage
{
    /// <summary>
    /// 组织表
    /// </summary>
    public class Organize : IEntity<Organize>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public int? Layers { get; set; }
        public string EnCode { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string CategoryId { get; set; }
        /// <summary>
        /// 主管主键
        /// </summary>
        public string ManagerId { get; set; }
        public string TelePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WeChat { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string AreaId { get; set; }
        public string Address { get; set; }
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
