/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Code;
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Domain.IRepository.SystemManage;
using Galaxy.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Galaxy.Service.SystemManage
{
    public class RoleService: IRoleService
    {
        private IUnitOfWork _unitOfWork;
        private IRoleRepository _roleRepository;
        private ModuleService moduleApp ;
        private ModuleButtonService moduleButtonApp ;

        public RoleService(IUnitOfWork unitOfWork, IRoleRepository roleRepository, IModuleButtonRepository moduleButtonRepository, IModuleRepository moduleRepository)
        {
            _unitOfWork = unitOfWork;
            _roleRepository = roleRepository;
            moduleApp = new ModuleService(_unitOfWork, moduleRepository);
            moduleButtonApp = new ModuleButtonService(_unitOfWork, moduleButtonRepository);
        }


        public List<Role> GetList(string keyword = "")
        {
            var expression = LinqExt.True<Role>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
                expression = expression.Or(t => t.EnCode.Contains(keyword));
            }
            expression = expression.And(t => t.Category == 1);
            return _roleRepository.IQueryable(expression).OrderBy(t => t.SortCode).ToList();
        }
        public Role GetForm(string keyValue)
        {
            return _roleRepository.Get(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            _roleRepository.DeleteForm(_unitOfWork, keyValue);
            _unitOfWork.Commit();
        }
        public void SubmitForm(Role roleEntity, string[] permissionIds, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                roleEntity.Id = keyValue;
            }
            else
            {
                roleEntity.Id = Common.GuId();
            }
            var moduledata = moduleApp.GetList();
            var buttondata = moduleButtonApp.GetList();
            List<RoleAuthorize> roleAuthorizeEntitys = new List<RoleAuthorize>();
            foreach (var itemId in permissionIds)
            {
                RoleAuthorize roleAuthorizeEntity = new RoleAuthorize();
                roleAuthorizeEntity.Id = Common.GuId();
                roleAuthorizeEntity.ObjectType = 1;
                roleAuthorizeEntity.ObjectId = roleEntity.Id;
                roleAuthorizeEntity.ItemId = itemId;
                if (moduledata.Find(t => t.Id == itemId) != null)
                {
                    roleAuthorizeEntity.ItemType = 1;
                }
                if (buttondata.Find(t => t.Id == itemId) != null)
                {
                    roleAuthorizeEntity.ItemType = 2;
                }
                roleAuthorizeEntitys.Add(roleAuthorizeEntity);
            }
            _roleRepository.SubmitForm(_unitOfWork,roleEntity, roleAuthorizeEntitys, keyValue);
            _unitOfWork.Commit();
        }
    }
}
