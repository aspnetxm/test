/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Galaxy.Entity.SystemSecurity;
using Galaxy.DTO.CommonModule;


namespace Galaxy.Service.SystemManage
{
    public interface ILogService
    {

        List<OprLog> GetList(Pagination pagination, string queryJson);


        Task RemoveLog(string keepTime);


        Task WriteLog(bool result, string resultLog, string ip);


        Task WriteLog(OprLog logEntity);

    }
}
