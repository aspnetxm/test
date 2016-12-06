/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System.Collections.Generic;

using Galaxy.Data.Infrastructure;
using Galaxy.Entity.SystemManage;

namespace Galaxy.Repository.Interface.SystemManage
{
    public interface IModuleButtonRepository : IRepositoryBase<ModuleButton>
    {
        void SubmitCloneButton(List<ModuleButton> entitys);
    }
}
