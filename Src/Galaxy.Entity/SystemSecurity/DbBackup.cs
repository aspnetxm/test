﻿/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;
using Galaxy.Entity.Infrastructure;

namespace Galaxy.Entity.SystemSecurity
{
    public class DbBackup : ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string Id { get; set; }
        public string BackupType { get; set; }
        public string DbName { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string FilePath { get; set; }
        public DateTime? BackupTime { get; set; }
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
