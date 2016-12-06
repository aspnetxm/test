/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Entity.SystemManage;

namespace Galaxy.Service.SystemManage
{
    public interface IUserLogOnServic
    {
        UserLogOn GetForm(string keyValue);

        void UpdateForm(UserLogOn userLogOnEntity);

        void RevisePassword(string userPassword, string keyValue);
    }
}
