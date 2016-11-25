using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Galaxy.Data
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);

        Task<bool> InsertAsync<TEntity>(TEntity entity)
            where TEntity : class;

        Task<bool> InsertAsync<TEntity>(IEnumerable<TEntity> entities)
          where TEntity : class;

        Task<bool> UpdateAsync<TEntity>(TEntity entity)
            where TEntity : class;

        Task<bool> CleanAsync<TEntity>(TEntity entity)
            where TEntity : class;

        Task<bool> DeleteAsync<TEntity>(TEntity entity)
            where TEntity : class;

        Task<bool> DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
           where TEntity : class;

        Task<bool> CommitAsync();

        void Rollback();
    }
}
