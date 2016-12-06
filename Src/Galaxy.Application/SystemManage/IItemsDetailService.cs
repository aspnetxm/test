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
    public interface IItemsDetailService
    {
        List<ItemsDetail> GetList(string itemId = "", string keyword = "");

        List<ItemsDetail> GetItemList(string enCode);

        ItemsDetail GetForm(string keyValue);

        void DeleteForm(string keyValue);

        void SubmitForm(ItemsDetail itemsDetailEntity, string keyValue);
    }
}
