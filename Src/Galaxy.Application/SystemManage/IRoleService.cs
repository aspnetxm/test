/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System.Linq;
using System.Collections.Generic;
using Galaxy.Entity.SystemManage;


namespace Galaxy.Service.SystemManage
{
    public interface IRoleService
    {
        List<Role> GetList(string keyword = "");

        Role GetForm(string keyValue);

        void DeleteForm(string keyValue);

        void SubmitForm(Role roleEntity, string[] permissionIds, string keyValue);
    }
}
