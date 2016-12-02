/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Repository.Infrastructure;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Repository.Interface.SystemManage;

namespace Galaxy.Repository.SystemManage
{
    public class AreaRepository :RepositoryBase<Area>, IAreaRepository
    {
        IUnitOfWork _unitOfWork;
        public AreaRepository(IUnitOfWork unitOfWork) : base(unitOfWork.DbContext)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
