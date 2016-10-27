/*******************************************************************************
 * 作者：星星    
 * 描述：系统日志
 * 修改记录： 
*********************************************************************************/
using System;

namespace Galaxy.Domain.Entity.SystemSecurity
{
    /// <summary>
    /// 系统日志
    /// </summary>
    public class LogEntity : IEntity<LogEntity>, ICreationAudited
    {
        public string Id { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Date { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// IP所在城市
        /// </summary>
        public string IPAddressName { get; set; }
        /// <summary>
        /// 系统模块Id
        /// </summary>
        public string ModuleId { get; set; }
        /// <summary>
        /// 系统模块
        /// </summary>
        public string ModuleName { get; set; }
        /// <summary>
        /// 结果
        /// </summary>
        public bool? Result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        public DateTime? CreatorTime { get; set; }
        public string CreatorUserId { get; set; }
    }
}
