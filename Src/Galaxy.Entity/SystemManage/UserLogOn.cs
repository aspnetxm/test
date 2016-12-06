/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;
using Galaxy.Entity.Infrastructure;

namespace Galaxy.Entity.SystemManage
{
    /// <summary>
    /// 用户登录信息表
    /// </summary>
    public class UserLogOn
    {
        public string Id { get; set; }
        /// <summary>
        /// 关联用户表Id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPassword { get; set; }
        /// <summary>
        /// 用户秘钥
        /// </summary>
        public string UserSecretkey { get; set; }
        /// <summary>
        /// 允许登录时间开始（锁定时有效）
        /// </summary>
        public DateTime? AllowStartTime { get; set; }
        /// <summary>
        /// 允许登录时间结束（锁定时有效）
        /// </summary>
        public DateTime? AllowEndTime { get; set; }
        /// <summary>
        /// 暂停用户开始日期（没被锁定时有效）
        /// </summary>
        public DateTime? LockStartDate { get; set; }
        /// <summary>
        /// 暂停用户结束日期（没被锁定时有效）
        /// </summary>
        public DateTime? LockEndDate { get; set; }
        /// <summary>
        /// 第一次访问时间
        /// </summary>
        public DateTime? FirstVisitTime { get; set; }
        /// <summary>
        /// 上一次访问时间
        /// </summary>
        public DateTime? PreviousVisitTime { get; set; }
        /// <summary>
        /// 最后访问时间
        /// </summary>
        public DateTime? LastVisitTime { get; set; }
        /// <summary>
        /// 最后修改密码日期
        /// </summary>
        public DateTime? ChangePasswordDate { get; set; }
        /// <summary>
        /// 允许同时有多用户登录
        /// </summary>
        public bool? MultiUserLogin { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        public int? LogOnCount { get; set; }
        /// <summary>
        /// 在线状态
        /// </summary>
        public bool? UserOnLine { get; set; }
        ///// <summary>
        ///// 密码提示问题
        ///// </summary>
        //public string Question { get; set; }
        ///// <summary>
        ///// 密码提示答案
        ///// </summary>
        //public string AnswerQuestion { get; set; }

        /// <summary>
        /// 是否限制访问IP
        /// </summary>
        public bool? CheckIPAddress { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string Language { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string Theme { get; set; }
    }
}