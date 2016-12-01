/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemManage;
using System.Collections.Generic;

namespace Galaxy.Domain.IRepository.SystemManage
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        void DeleteForm(string keyValue);
        void SubmitForm(Role roleEntity, List<RoleAuthorize> roleAuthorizeEntitys, string keyValue);
    }
}
