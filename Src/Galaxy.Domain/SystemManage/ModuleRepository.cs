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
    public class ModuleRepository : BaseRepository<Module>, IModuleRepository
    {
        IDbContext _dbContext;
        public ModuleRepository(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
