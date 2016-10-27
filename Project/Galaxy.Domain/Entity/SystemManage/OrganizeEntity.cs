/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;

namespace Galaxy.Domain.Entity.SystemManage
{
    /// <summary>
    /// 组织表
    /// </summary>
    public class OrganizeEntity : IEntity<OrganizeEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
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
        /// 简称
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string CategoryId { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string ManagerId { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string TelPhone { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 微信
        /// </summary>
        public string WeChat { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 归属区域
        /// </summary>
        public string AreaId { get; set; }
        /// <summary>
        /// 联系地址
        /// </summary>
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
