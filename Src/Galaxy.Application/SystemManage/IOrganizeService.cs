/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using Galaxy.Entity.SystemManage;

namespace Galaxy.Service.SystemManage
{
    public interface IOrganizeService
    {
        List<Organize> GetList();

        Organize GetForm(string keyValue);

        void DeleteForm(string keyValue);

        void SubmitForm(Organize organizeEntity, string keyValue, string userId);
    }
}
