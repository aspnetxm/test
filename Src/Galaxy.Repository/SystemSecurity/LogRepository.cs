/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Repository.Infrastructure;
using Galaxy.Domain.Entity.SystemSecurity;
using Galaxy.Repository.Interface.SystemSecurity;

namespace Galaxy.Repository.SystemSecurity
{
    public class LogRepository : RepositoryBase<OprLog>, ILogRepository
    {
        IUnitOfWork _unitOfWork;
        public LogRepository(IUnitOfWork unitOfWork) : base(unitOfWork.DbContext)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
