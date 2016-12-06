/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data.Infrastructure;
using Galaxy.Entity.SystemManage;
using Galaxy.Repository.Interface.SystemManage;

namespace Galaxy.Repository.SystemManage
{
    public class UserLogOnRepository : RepositoryBase<UserLogOn>, IUserLogOnRepository
    {
        IUnitOfWork _unitOfWork;
        public UserLogOnRepository(IUnitOfWork unitOfWork) : base(unitOfWork.DbContext)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
