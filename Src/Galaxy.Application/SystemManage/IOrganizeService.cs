/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;

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
