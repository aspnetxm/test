/*******************************************************************************
 * 作者：星星    
 * 描述：   
 * 修改记录： 
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Galaxy.Data
{
    public class RepBase<TEntity> : IRepBase<TEntity> where TEntity : class, new()
    {
        IUnitOfWork _uk;
        public RepBase(IUnitOfWork unitOfWork)
        {
            _uk = unitOfWork;
        }

        public bool Insert(TEntity entity)
        {
            return _uk.Insert(entity);
        }
        public async Task<bool> InsertAsync(TEntity entity)
        {
            return await _uk.InsertAsync(entity);
        }
        public bool Insert(List<TEntity> entitys)
        {
            return _uk.Insert(entitys);
        }
        public async Task<bool> InsertAsync(List<TEntity> entitys)
        {
            return await _uk.InsertAsync(entitys);
        }
        public bool Update(TEntity entity)
        {
            return _uk.Update(entity);
        }
        public async Task<bool> UpdateAsync(TEntity entity)
        {
            return await _uk.UpdateAsync(entity);
        }
        public bool Delete(TEntity entity)
        {
            return _uk.Delete(entity);
        }
        public async Task<bool> DeleteAsync(TEntity entity)
        {
            return await _uk.DeleteAsync(entity);
        }
        public bool Delete(Expression<Func<TEntity, bool>> predicate)
        {
            return _uk.Delete(predicate);
        }
        public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _uk.DeleteAsync(predicate);
        }
    }
}
