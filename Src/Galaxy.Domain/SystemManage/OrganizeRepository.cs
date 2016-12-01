/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Repository.Interface.SystemManage;
using Galaxy.Repository.SystemManage;

namespace Galaxy.Repository.SystemManage
{
    public class OrganizeRepository : BaseRepository<Organize>, IOrganizeRepository
    {
        IUnitOfWork _unitOfWork;
        public OrganizeRepository(IUnitOfWork unitOfWork) : base(unitOfWork.DbContext)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
