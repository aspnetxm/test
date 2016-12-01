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
        private bool isUnitWork = false;

        public UnitOfWork()
        {
            _dbContext = new GalaxyDbContext();
        }

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BeginTransaction(bool unitWork = false)
        {
            if (!unitWork)
            {
                isUnitWork = false;
                _dbTransaction = _dbContext.Database.BeginTransaction();
            }
            else
            {
                _dbTransaction = null;
                isUnitWork = true;
            }
        }

        public bool IsUnitWork { get { return isUnitWork;  } }

        public IDbContext DbContext
        {
            get
            {
                return _dbContext;
            }
        }

        public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await _dbContext.Database.ExecuteSqlCommandAsync(sql, parameters);
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _dbContext.Database.ExecuteSqlCommand(sql, parameters);
        }

        public async Task<bool> InsertAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Add(entity);
            if (_dbTransaction != null || !IsUnitWork)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public bool Insert<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Add(entity);
            if (_dbTransaction != null || !IsUnitWork)
                return _dbContext.SaveChanges() > 0;
            return true;
        }

        public async Task<bool> InsertAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            foreach (TEntity entity in entities)
                _dbContext.Set<TEntity>().Add(entity);

            if (_dbTransaction != null || !IsUnitWork)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public bool Insert<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            foreach (TEntity entity in entities)
                _dbContext.Set<TEntity>().Add(entity);

            if (_dbTransaction != null || !IsUnitWork)
                return _dbContext.SaveChanges() > 0;
            return true;
        }

        public async Task<bool> UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
            if (_dbTransaction != null || !IsUnitWork)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public bool Update<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
            if (_dbTransaction != null || !IsUnitWork)
                return _dbContext.SaveChanges() > 0;
            return true;
        }

        public async Task<bool> CleanAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Unchanged;
            if (_dbTransaction != null || !IsUnitWork)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public bool Clean<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Unchanged;
            if (_dbTransaction != null || !IsUnitWork)
                return _dbContext.SaveChanges() > 0;
            return true;
        }

        public async Task<bool> DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var entitys = _dbContext.Set<TEntity>().Where(predicate).ToList();
            entitys.ForEach(m => _dbContext.Entry<TEntity>(m).State = EntityState.Deleted);
            if (_dbTransaction != null || !IsUnitWork)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public bool Delete<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var entitys = _dbContext.Set<TEntity>().Where(predicate).ToList();
            entitys.ForEach(m => _dbContext.Entry<TEntity>(m).State = EntityState.Deleted);
            if (_dbTransaction != null || !IsUnitWork)
                return _dbContext.SaveChanges() > 0;
            return true;
        }

        public async Task<bool> DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Remove(entity);
            if (_dbTransaction != null || !IsUnitWork)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public bool Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Remove(entity);
            if (_dbTransaction != null || !IsUnitWork)
                return _dbContext.SaveChanges() > 0;
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

        public bool Commit()
        {
            if (IsUnitWork&& _dbTransaction==null)
                return _dbContext.SaveChanges() > 0;
            else if (_dbTransaction != null)
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