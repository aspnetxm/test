/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Code;
using Galaxy.Data;
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Repository.Interface.SystemManage;
using Galaxy.Service.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Galaxy.Service.SystemManage
{
    public class ModuleService: IModuleService
    {
        private IModuleRepository _moduleRepository;
        private IUnitOfWork _unitOfWork;

        public ModuleService(IUnitOfWork unitOfWork, IModuleRepository moduleRepository)
        {
            _unitOfWork = unitOfWork;
            _moduleRepository = moduleRepository;
        }

        public List<Module> GetList()
        {
            return _moduleRepository.IQueryable().OrderBy(t => t.SortCode).ToList();
        }
        public Module GetForm(string keyValue)
        {
            return _moduleRepository.Get(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            if (_moduleRepository.IQueryable().Count(t => t.ParentId.Equals(keyValue)) > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                _unitOfWork.Delete<Module>(t => t.Id == keyValue);
            }
        }
        public void SubmitForm(Module moduleEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                moduleEntity.Modify(keyValue);
                _unitOfWork.Update(moduleEntity);
            }
            else
            {
                moduleEntity.Create();
                _unitOfWork.Insert(moduleEntity);
            }
        }
    }
}
