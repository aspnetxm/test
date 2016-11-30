/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Code;
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Domain.IRepository.SystemManage;
using System.Collections.Generic;
using System.Linq;

namespace Galaxy.Service.Interfaces
{
    public interface IItemsDetailService
    {
        List<ItemsDetail> GetList(string itemId = "", string keyword = "");

        List<ItemsDetail> GetItemList(string enCode);

        ItemsDetail GetForm(string keyValue);

        void DeleteForm(string keyValue);

        void SubmitForm(ItemsDetail itemsDetailEntity, string keyValue);
    }
}
