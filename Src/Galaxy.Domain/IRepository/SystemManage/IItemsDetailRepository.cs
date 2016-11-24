﻿/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemManage;
using System.Collections.Generic;

namespace Galaxy.IRepository.SystemManage
{
    public interface IItemsDetailRepository : IRepositoryBase<ItemsDetail>
    {
        List<ItemsDetail> GetItemList(string enCode);
    }
}
