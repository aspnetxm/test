using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.Data
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        Task<TEntity> GetAsync(object keyValue);

        TEntity Get(object keyValue);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> IQueryable();

        IQueryable<TEntity> IQueryable(Expression<Func<TEntity, bool>> predicate);

        List<TEntity> FindList(string strSql);

        List<TEntity> FindList(string strSql, object[] dbParameter);

        Task<List<TEntity>> FindListAsync(Pagination pagination);

        List<TEntity> FindList(Pagination pagination);

        Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> predicate, Pagination pagination);

        List<TEntity> FindList(Expression<Func<TEntity, bool>> predicate, Pagination pagination);
    }
}
