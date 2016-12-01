/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using Galaxy.Code;
using Galaxy.Data;
using Galaxy.Domain.Dto;
using Galaxy.Repository.Interface.SystemManage;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Repository.SystemManage;

namespace Galaxy.Service.SystemManage
{
    public interface IRoleAuthorizeService
    {
        List<RoleAuthorize> GetList(string ObjectId);

        List<Module> GetMenuList(string roleId);

        List<ModuleButton> GetButtonList(string roleId);

        bool ActionValidate(string roleId, string moduleId, string action);
    }
}
