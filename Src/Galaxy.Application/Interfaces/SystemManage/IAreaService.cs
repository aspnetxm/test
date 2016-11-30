﻿/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.Domain.Entity.SystemManage;


namespace Galaxy.Service.Interfaces
{
    public interface IAreaService
    {
        List<Area> GetList();

        Task<Area> GetForm(string keyValue);

        Task DeleteForm(string keyValue);

        void SubmitForm(Area areaEntity, string keyValue);
       
    }
}
