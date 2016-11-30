/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Galaxy.Code;
using Galaxy.Domain.Entity.SystemSecurity;
using Galaxy.Domain.IRepository.SystemSecurity;
using Galaxy.Data;


namespace Galaxy.Service.Interfaces
{
    public interface ILogService
    {

        List<OprLog> GetList(Pagination pagination, string queryJson);


        Task RemoveLog(string keepTime);


        Task WriteLog(bool result, string resultLog, string ip);


        Task WriteLog(OprLog logEntity);

    }
}
