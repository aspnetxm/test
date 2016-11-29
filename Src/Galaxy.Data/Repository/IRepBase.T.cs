/*******************************************************************************
 * 作者：星星    
 * 描述：   
 * 修改记录： 
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Galaxy.Data
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IRepBase<TEntity> where TEntity : class, new()
    {
        bool Insert(TEntity entity);
        Task<bool> InsertAsync(TEntity entity);
        bool Insert(List<TEntity> entitys);
        Task<bool> InsertAsync(List<TEntity> entitys);
        bool Update(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        bool Delete(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        bool Delete(Expression<Func<TEntity, bool>> predicate);
        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
