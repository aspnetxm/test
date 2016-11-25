/*******************************************************************************
 * 作者：星星    
 * 描述：  
 * 修改记录： 
*********************************************************************************/
using Galaxy.Domain.Entity.SystemManage;
using Galaxy.Domain.IRepository.SystemManage;
using Galaxy.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Galaxy.Application.SystemManage
{
    public class OrganizeApp
    {
        private IOrganizeRepository service = new OrganizeRepository();

        public List<Organize> GetList()
        {
            return service.IQueryable().OrderBy(t => t.CreatorTime).ToList();
        }
        public Organize GetForm(string keyValue)
        {
            return service.Get(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            if (service.IQueryable().Count(t => t.ParentId.Equals(keyValue)) > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                service.Delete(t => t.Id == keyValue);
            }
        }
        public void SubmitForm(Organize organizeEntity, string keyValue,string userId)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                organizeEntity.Modify(userId);
                service.Update(organizeEntity);
            }
            else
            {
                organizeEntity.Create(userId);
                service.Insert(organizeEntity);
            }
        }
    }
}
