/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Domain.IRepository.SystemManage;
using Galaxy.Repository.SystemManage;

namespace Galaxy.Repository.SystemManage
{
    public class OrganizeRepository : BaseRepository<Organize>, IOrganizeRepository
    {
        IDbContext _dbContext;
        public OrganizeRepository(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
