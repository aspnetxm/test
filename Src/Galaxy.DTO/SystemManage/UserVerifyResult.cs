/*******************************************************************************
 * 作者：星星    
 * 描述：用户验证返回结果   
 * 修改记录： 
*********************************************************************************/

using Galaxy.Domain.Entity.SystemManage;

namespace Galaxy.Domain.Dto
{
    public class UserVerifyDTO
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuc { get; set; }
        /// <summary>
        /// 错误描述
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// 成功返回用户
        /// </summary>
        public User User { get; set; }
    }
}
