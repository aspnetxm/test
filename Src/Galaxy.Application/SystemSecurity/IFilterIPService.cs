/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Code;
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemSecurity;
using Galaxy.Domain.IRepository.SystemSecurity;
using Galaxy.Repository.SystemSecurity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Service.SystemManage
{
    public interface IFilterIPService
    {
        List<FilterIP> GetList(string keyword);

        Task<FilterIP> GetForm(string keyValue);

        Task DeleteForm(string keyValue);

        Task SubmitForm(FilterIP filterIPEntity, string keyValue);

    }
}
