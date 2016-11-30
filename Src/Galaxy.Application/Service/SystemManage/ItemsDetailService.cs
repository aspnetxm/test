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
    public class ItemsDetailService : IItemsDetailService
    {
        private IItemsDetailRepository _itemsDetailRepository;
        private IUnitOfWork _unitOfWork;

        public ItemsDetailService(IUnitOfWork unitOfWork, IItemsDetailRepository itemsDetailRepository)
        {
            _unitOfWork = unitOfWork;
            _itemsDetailRepository = itemsDetailRepository;
        }

        public List<ItemsDetail> GetList(string itemId = "", string keyword = "")
        {
            var expression = LinqExt.True<ItemsDetail>();
            if (!string.IsNullOrEmpty(itemId))
            {
                expression = expression.And(t => t.ItemId == itemId);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.ItemName.Contains(keyword));
                expression = expression.Or(t => t.ItemCode.Contains(keyword));
            }
            return _itemsDetailRepository.IQueryable(expression).OrderBy(t => t.SortCode).ToList();
        }
        public List<ItemsDetail> GetItemList(string enCode)
        {
            return _itemsDetailRepository.GetItemList(enCode);
        }
        public ItemsDetail GetForm(string keyValue)
        {
            return _itemsDetailRepository.Get(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            _unitOfWork.Delete<ItemsDetail>(t => t.Id == keyValue);
        }
        public void SubmitForm(ItemsDetail itemsDetailEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                itemsDetailEntity.Modify(keyValue);
                _unitOfWork.Update(itemsDetailEntity);
            }
            else
            {
                itemsDetailEntity.Create();
                _unitOfWork.Insert(itemsDetailEntity);
            }
            _unitOfWork.Commit();
        }
    }
}
