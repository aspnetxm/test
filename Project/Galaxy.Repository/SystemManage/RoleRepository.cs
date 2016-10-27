/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Domain.IRepository.SystemManage;
using Galaxy.Repository.SystemManage;
using System.Collections.Generic;

namespace Galaxy.Repository.SystemManage
{
    public class RoleRepository : RepositoryBase<RoleEntity>, IRoleRepository
    {
        public void DeleteForm(string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                db.Delete<RoleEntity>(t => t.Id == keyValue);
                db.Delete<RoleAuthorizeEntity>(t => t.ObjectId == keyValue);
                db.Commit();
            }
        }
        public void SubmitForm(RoleEntity roleEntity, List<RoleAuthorizeEntity> roleAuthorizeEntitys, string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    db.Update(roleEntity);
                }
                else
                {
                    roleEntity.Category = 1;
                    db.Insert(roleEntity);
                }
                db.Delete<RoleAuthorizeEntity>(t => t.ObjectId == roleEntity.Id);
                db.Insert(roleAuthorizeEntitys);
                db.Commit();
            }
        }
    }
}
