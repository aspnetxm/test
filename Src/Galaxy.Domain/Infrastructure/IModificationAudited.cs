/*******************************************************************************
 * 作者：星星    
 * 描述： 
 * 修改记录： 
*********************************************************************************/
using System;

namespace Galaxy.Domain
{
    public interface IModificationAudited
    {
        string Id { get; set; }
        string LastModifyUserId { get; set; }
        DateTime? LastModifyTime { get; set; }
    }
}