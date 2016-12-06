/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data.Infrastructure;
using Galaxy.Entity.SystemSecurity;
using Galaxy.Repository.Interface.SystemSecurity;

namespace Galaxy.Repository.SystemSecurity
{
    public class FilterIPRepository : RepositoryBase<FilterIP>, IFilterIPRepository
    {
        IUnitOfWork _unitOfWork;
        public FilterIPRepository(IUnitOfWork unitOfWork) : base(unitOfWork.DbContext)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
