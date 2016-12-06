/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System.Collections.Generic;
using Galaxy.Data.Infrastructure;
using Galaxy.Entity.SystemManage;
using Galaxy.Repository.Interface.SystemManage;


namespace Galaxy.Repository.SystemManage
{
    public class ModuleButtonRepository : RepositoryBase<ModuleButton>, IModuleButtonRepository
    {
        IUnitOfWork _unitOfWork;
        public ModuleButtonRepository(IUnitOfWork unitOfWork) : base(unitOfWork.DbContext)
        {
            _unitOfWork = unitOfWork;
        }
        public void SubmitCloneButton(List<ModuleButton> entitys)
        {
            foreach (var item in entitys)
            {
                _unitOfWork.Insert(item);
            }
        }
    }
}
