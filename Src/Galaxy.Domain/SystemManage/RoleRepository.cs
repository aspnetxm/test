/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Domain.IRepository.SystemManage;
using System.Collections.Generic;

namespace Galaxy.Repository.SystemManage
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        IDbContext _dbContext;
        public RoleRepository(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteForm(IUnitOfWork uk, string keyValue)
        {
            uk.Delete<Role>(t => t.Id == keyValue);
            uk.Delete<RoleAuthorize>(t => t.ObjectId == keyValue);
        }
        public void SubmitForm(IUnitOfWork uk, Role roleEntity, List<RoleAuthorize> roleAuthorizeEntitys, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                uk.Update(roleEntity);
            }
            else
            {
                roleEntity.Category = 1;
                uk.Insert(roleEntity);
            }
            uk.Delete<RoleAuthorize>(t => t.ObjectId == roleEntity.Id);
            uk.Insert(roleAuthorizeEntitys);
        }
    }
}
