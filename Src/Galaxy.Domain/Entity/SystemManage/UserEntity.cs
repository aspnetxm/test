/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;

namespace Galaxy.Domain.Entity.SystemManage
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class UserEntity : IEntity<UserEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string Id { get; set; }
        /// <summary>
        /// 帐号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadIcon { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public bool? Gender { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 微信
        /// </summary>
        public string WeChat { get; set; }
        /// <summary>
        /// 安全级别
        /// </summary>
        public int? SecurityLevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Signature { get; set; }
        /// <summary>
        /// 主管主键
        /// </summary>
        public string ManagerId { get; set; }
        /// <summary>
        /// 组织主键
        /// </summary>
        public string OrganizeId { get; set; }
        /// <summary>
        /// 部门主键
        /// </summary>
        public string DepartmentId { get; set; }
        /// <summary>
        /// 角色主键
        /// </summary>
        public string RoleId { get; set; }
        /// <summary>
        /// 岗位主键
        /// </summary>
        public string DutyId { get; set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool? IsAdministrator { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }
        /// <summary>
        /// 删除标志
        /// </summary>
        public bool? DeleteMark { get; set; }
        /// <summary>
        /// 有效标志 (登录)
        /// </summary>
        public bool? EnabledMark { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? CreatorTime { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        public string CreatorUserId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }
        /// <summary>
        /// 最后修改用户
        /// </summary>
        public string LastModifyUserId { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }
        /// <summary>
        /// 删除用户
        /// </summary>
        public string DeleteUserId { get; set; }
    }
}
