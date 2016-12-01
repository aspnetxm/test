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
    public class ModuleButtonService: IModuleButtonService
    {
        private IUnitOfWork _unitOfWork;
        private IModuleButtonRepository _moduleButtonRepository;

        public ModuleButtonService(IUnitOfWork unitOfWork, IModuleButtonRepository moduleButtonRepository)
        {
            _unitOfWork = unitOfWork;
            _moduleButtonRepository = moduleButtonRepository;
        }

        public List<ModuleButton> GetList(string moduleId = "")
        {
            var expression = LinqExt.True<ModuleButton>();
            if (!string.IsNullOrEmpty(moduleId))
            {
                expression = expression.And(t => t.ModuleId == moduleId);
            }
            return _moduleButtonRepository.IQueryable(expression).OrderBy(t => t.SortCode).ToList();
        }
        public ModuleButton GetForm(string keyValue)
        {
            return _moduleButtonRepository.Get(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            if (_moduleButtonRepository.IQueryable().Count(t => t.ParentId.Equals(keyValue)) > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                _unitOfWork.Delete<ModuleButton>(t => t.Id == keyValue);
                _unitOfWork.Commit();
            }
        }
        public void SubmitForm(ModuleButton moduleButtonEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                moduleButtonEntity.Modify(keyValue);
                _unitOfWork.Update(moduleButtonEntity);
            }
            else
            {
                moduleButtonEntity.Create();
                _unitOfWork.Insert(moduleButtonEntity);
            }
            _unitOfWork.Commit();
        }
        public void SubmitCloneButton(string moduleId, string Ids)
        {
            string[] ArrayId = Ids.Split(',');
            var data = this.GetList();
            List<ModuleButton> entitys = new List<ModuleButton>();
            foreach (string item in ArrayId)
            {
                ModuleButton moduleButtonEntity = data.Find(t => t.Id == item);
                moduleButtonEntity.Id = Common.GuId();
                moduleButtonEntity.ModuleId = moduleId;
                entitys.Add(moduleButtonEntity);
            }

            foreach (var item in entitys)
            {
                _unitOfWork.Insert(item);
            }
            _unitOfWork.Commit();
        }
    }
}
