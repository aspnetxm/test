/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Domain.IRepository.SystemManage;
using Galaxy.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Galaxy.Service.SystemManage
{
    public class OrganizeService: IOrganizeService
    {
        private IUnitOfWork _unitOfWork;
        private IOrganizeRepository _organizeRepository;

        public OrganizeService(IUnitOfWork unitOfWork, IOrganizeRepository organizeRepository)
        {
            _unitOfWork = unitOfWork;
            _organizeRepository = organizeRepository;
        }

        public List<Organize> GetList()
        {
            return _organizeRepository.IQueryable().OrderBy(t => t.CreatorTime).ToList();
        }
        public Organize GetForm(string keyValue)
        {
            return _organizeRepository.Get(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            if (_organizeRepository.IQueryable().Count(t => t.ParentId.Equals(keyValue)) > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                _unitOfWork.Delete<Organize>(t => t.Id == keyValue);
                _unitOfWork.Commit();
            }
        }
        public void SubmitForm(Organize organizeEntity, string keyValue, string userId)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                organizeEntity.Modify(userId);
                _unitOfWork.Update(organizeEntity);
            }
            else
            {
                organizeEntity.Create(userId);
                _unitOfWork.Insert(organizeEntity);
            }
            _unitOfWork.Commit();
        }
    }
}
