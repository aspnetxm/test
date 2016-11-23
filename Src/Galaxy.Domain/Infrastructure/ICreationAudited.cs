/*******************************************************************************
 * 作者：星星    
 * 描述： 
 * 修改记录： 
*********************************************************************************/
using System;

namespace Galaxy.Domain
{
    public interface ICreationAudited
    {
        string Id { get; set; }
        string CreatorUserId { get; set; }
        DateTime? CreatorTime { get; set; }
    }
}