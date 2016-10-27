/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;

namespace Galaxy.Domain.Entity.SystemManage
{
    /// <summary>
    /// 角色授权表
    /// </summary>
    public class RoleAuthorizeEntity : IEntity<RoleAuthorizeEntity>, ICreationAudited
    {
        public string Id { get; set; }
        /// <summary>
        /// 项目类型1-模块2-按钮3-列表
        /// </summary>
        public int? ItemType { get; set; }
        /// <summary>
        /// 项目主键
        /// </summary>
        public string ItemId { get; set; }
        /// <summary>
        /// 对象分类1-角色2-部门-3用户
        /// </summary>
        public int? ObjectType { get; set; }
        /// <summary>
        /// 对象主键
        /// </summary>
        public string ObjectId { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }


        public DateTime? CreatorTime { get; set; }
        public string CreatorUserId { get; set; }
    }
}
