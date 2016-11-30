/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Domain.IRepository.SystemManage;
using Galaxy.Service.Interfaces;
using Galaxy.Data;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Galaxy.Service.SystemManage
{
    public class ItemsService: IItemsService
    {
        private IItemsRepository _itemsRepository;
        private IUnitOfWork _unitOfWork;

        public ItemsService(IUnitOfWork unitOfWork, IItemsRepository itemsRepository)
        {
            _unitOfWork = unitOfWork;
            _itemsRepository = itemsRepository;
        }

        public List<Items> GetList()
        {
            return _itemsRepository.IQueryable().ToList();
        }
        public Items GetForm(string keyValue)
        {
            return _itemsRepository.Get(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            if (_itemsRepository.IQueryable().Count(t => t.ParentId.Equals(keyValue)) > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                _unitOfWork.Delete<Items>(t => t.Id == keyValue);
                _unitOfWork.Commit();
            }
        }
        public void SubmitForm(Items itemsEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                itemsEntity.Modify(keyValue);
                _unitOfWork.Update(itemsEntity);
                _unitOfWork.Commit();
            }
            else
            {
                itemsEntity.Create();
                _unitOfWork.Insert(itemsEntity);
                _unitOfWork.Commit();
            }
        }
    }
}
