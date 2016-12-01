/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Code;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Repository.Interface.SystemManage;
using Galaxy.Repository.SystemManage;
using Galaxy.Data;

namespace Galaxy.Service.SystemManage
{
    public interface IUserLogOnServic
    {
        UserLogOn GetForm(string keyValue);

        void UpdateForm(UserLogOn userLogOnEntity);

        void RevisePassword(string userPassword, string keyValue);
    }
}
