/*******************************************************************************
 * 作者：星星    
 * 描述： 
 * 修改记录： 
*********************************************************************************/
using System;

namespace Galaxy.Domain.Infrastructure
{
    public class IEntity<TEntity>
    {
        public void Create(string UserId = "")
        {
            var entity = this as ICreationAudited;
            entity.Id = Guid.NewGuid().ToString();
            if (!string.IsNullOrWhiteSpace(UserId))
            {
                entity.CreatorUserId = UserId;
            }
            entity.CreatorTime = DateTime.Now;
        }
        public void Modify(string UserId = "")
        {
            var entity = this as IModificationAudited;
            if (!string.IsNullOrWhiteSpace(UserId))
            {
                entity.LastModifyUserId = UserId;
            }
            entity.LastModifyTime = DateTime.Now;
        }
        public void Remove(string UserId = "")
        {
            var entity = this as IDeleteAudited;
            if (!string.IsNullOrWhiteSpace(UserId))
            {
                entity.DeleteUserId = UserId;
            }
            entity.DeleteTime = DateTime.Now;
            entity.DeleteMark = true;
        }
    }
}
