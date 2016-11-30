/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemSecurity;
using Galaxy.Domain.IRepository.SystemSecurity;

namespace Galaxy.Repository.SystemSecurity
{
    public class FilterIPRepository : BaseRepository<FilterIP>, IFilterIPRepository
    {
        IDbContext _dbContext;
        public FilterIPRepository(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
