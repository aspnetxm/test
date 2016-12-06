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
    public interface IModuleService
    {
        List<Module> GetList();

        Module GetForm(string keyValue);

        void DeleteForm(string keyValue);

        void SubmitForm(Module moduleEntity, string keyValue);
    }
}
