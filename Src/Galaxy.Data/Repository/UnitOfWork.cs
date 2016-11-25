using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Galaxy.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;
        private DbContextTransaction _dbTransaction;

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BeginTransaction()
        {
            _dbTransaction = _dbContext.Database.BeginTransaction();
        }

        public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await _dbContext.Database.ExecuteSqlCommandAsync(sql, parameters);
        }

        public async Task<bool> InsertAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            _dbContext.Set<TEntity>().Add(entity);
            if (_dbTransaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public async Task<bool> InsertAsync<TEntity>(IEnumerable<TEntity> entities)
           where TEntity : class
        {
            foreach (TEntity entity in entities)
                _dbContext.Set<TEntity>().Add(entity);

            if (_dbTransaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public async Task<bool> UpdateAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
            if (_dbTransaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public async Task<bool> CleanAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Unchanged;
            if (_dbTransaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public async Task<bool> DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class
        {
            var entitys = _dbContext.Set<TEntity>().Where(predicate).ToList();
            entitys.ForEach(m => _dbContext.Entry<TEntity>(m).State = EntityState.Deleted);
            if (_dbTransaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public async Task<bool> DeleteAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            _dbContext.Set<TEntity>().Remove(entity);
            if (_dbTransaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public async Task<bool> CommitAsync()
        {
            if (_dbTransaction == null)
                return await _dbContext.SaveChangesAsync() > 0;
            else
                _dbTransaction.Commit();

            _dbTransaction.Dispose();
            return true;
        }

        public void Rollback()
        {
            if (_dbTransaction != null)
                _dbTransaction.Rollback();
        }
    }
}