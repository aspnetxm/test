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
    public class RoleAuthorizeRepository : RepositoryBase<RoleAuthorize>, IRoleAuthorizeRepository
    {
        IUnitOfWork _unitOfWork;
        public RoleAuthorizeRepository(IUnitOfWork unitOfWork) : base(unitOfWork.DbContext)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
