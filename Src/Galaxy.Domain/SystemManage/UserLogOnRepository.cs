/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Domain.IRepository.SystemManage;

namespace Galaxy.Repository.SystemManage
{
    public class UserLogOnRepository : BaseRepository<UserLogOn>, IUserLogOnRepository
    {
        IDbContext _dbContext;
        public UserLogOnRepository(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
