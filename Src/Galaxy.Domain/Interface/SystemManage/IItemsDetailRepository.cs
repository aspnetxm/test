/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemManage;
using System.Collections.Generic;

namespace Galaxy.Repository.Interface.SystemManage
{
    public interface IItemsDetailRepository : IBaseRepository<ItemsDetail>
    {
        List<ItemsDetail> GetItemList(string enCode);
    }
}
