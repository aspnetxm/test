﻿/*******************************************************************************
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
    public interface IModuleButtonService
    {
        List<ModuleButton> GetList(string moduleId = "");

        ModuleButton GetForm(string keyValue);

        void DeleteForm(string keyValue);

        void SubmitForm(ModuleButton moduleButtonEntity, string keyValue);

        void SubmitCloneButton(string moduleId, string Ids);
    }
}
