/*******************************************************************************
 * 作者：星星     
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Code;
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Domain.IRepository.SystemManage;
using Galaxy.Repository.SystemManage;
using System.Collections.Generic;
using System.Linq;

namespace Galaxy.Service.Interfaces
{
    public interface IDutyService
    {
        List<Role> GetList(string keyword = "");

        Role GetForm(string keyValue);

        void DeleteForm(string keyValue);

        void SubmitForm(Role roleEntity, string keyValue);
        
    }
}
