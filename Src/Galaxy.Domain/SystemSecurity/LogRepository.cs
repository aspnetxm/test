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
    public class LogRepository : BaseRepository<OprLog>, ILogRepository
    {
        IDbContext _dbContext;
        public LogRepository(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
