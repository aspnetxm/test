﻿/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System.Collections.Generic;
using Galaxy.Data.Infrastructure;
using Galaxy.Entity.SystemManage;


namespace Galaxy.Repository.Interface.SystemManage
{
    public interface IRoleRepository : IRepositoryBase<Role>
    {
        void DeleteForm(string keyValue);
        void SubmitForm(Role roleEntity, List<RoleAuthorize> roleAuthorizeEntitys, string keyValue);
    }
}
