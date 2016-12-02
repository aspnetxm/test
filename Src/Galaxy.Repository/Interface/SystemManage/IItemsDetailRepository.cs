/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System.Collections.Generic;
using Galaxy.Repository.Infrastructure;
using Galaxy.Domain.Entity.SystemManage;

namespace Galaxy.Repository.Interface.SystemManage
{
    public interface IItemsDetailRepository : IRepositoryBase<ItemsDetail>
    {
        List<ItemsDetail> GetItemList(string enCode);
    }
}
