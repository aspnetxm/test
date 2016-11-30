/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Domain.IRepository.SystemManage;
using Galaxy.Repository.SystemManage;
using Galaxy.Data;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Galaxy.Service.Interfaces
{
    public interface IItemsService
    {

        List<Items> GetList();

        Items GetForm(string keyValue);

        void DeleteForm(string keyValue);

        void SubmitForm(Items itemsEntity, string keyValue);
        
    }
}
