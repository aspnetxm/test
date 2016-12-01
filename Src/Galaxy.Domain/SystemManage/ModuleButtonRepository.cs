/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Repository.Interface.SystemManage;
using System.Collections.Generic;

namespace Galaxy.Repository.SystemManage
{
    public class ModuleButtonRepository : BaseRepository<ModuleButton>, IModuleButtonRepository
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
