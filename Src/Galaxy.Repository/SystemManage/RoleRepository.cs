/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using System.Collections.Generic;
using Galaxy.Data.Infrastructure;
using Galaxy.Entity.SystemManage;
using Galaxy.Repository.Interface.SystemManage;


namespace Galaxy.Repository.SystemManage
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {

        IUnitOfWork _unitOfWork;
        public RoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork.DbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteForm(string keyValue)
        {
            _unitOfWork.Delete<Role>(t => t.Id == keyValue);
            _unitOfWork.Delete<RoleAuthorize>(t => t.ObjectId == keyValue);
        }

        public void SubmitForm(Role roleEntity, List<RoleAuthorize> roleAuthorizeEntitys, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                _unitOfWork.Update(roleEntity);
            }
            else
            {
                roleEntity.Category = 1;
                _unitOfWork.Insert(roleEntity);
            }
            _unitOfWork.Delete<RoleAuthorize>(t => t.ObjectId == roleEntity.Id);
            _unitOfWork.Insert(roleAuthorizeEntitys);
        }
    }
}
