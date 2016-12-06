/*******************************************************************************
 * 作者：星星     
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Utility;
using Galaxy.Data.Infrastructure;
using Galaxy.Entity.SystemManage;
using Galaxy.Repository.Interface.SystemManage;
using System.Collections.Generic;
using System.Linq;

namespace Galaxy.Service.SystemManage
{
    public class DutyService: IDutyService
    {
        private IRoleRepository _roleRepository ;
        private IUnitOfWork _unitOfWork;

        public DutyService(IUnitOfWork unitOfWork, IRoleRepository roleRepository)
        {
            _unitOfWork = unitOfWork;
            _roleRepository = roleRepository;
        }

        public List<Role> GetList(string keyword = "")
        {
            var expression = LinqExt.True<Role>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
                expression = expression.Or(t => t.EnCode.Contains(keyword));
            }
            expression = expression.And(t => t.Category == 2);
            return _roleRepository.IQueryable(expression).OrderBy(t => t.SortCode).ToList();
        }
        public Role GetForm(string keyValue)
        {
            return _roleRepository.Get(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            _unitOfWork.Delete<Role>(t => t.Id == keyValue);
            _unitOfWork.Commit();
        }
        public void SubmitForm(Role roleEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                roleEntity.Modify(keyValue);
                _unitOfWork.Update(roleEntity);
            }
            else
            {
                roleEntity.Create();
                roleEntity.Category = 2;
                _unitOfWork.Insert(roleEntity);
            }
            _unitOfWork.Commit();
        }
    }
}
