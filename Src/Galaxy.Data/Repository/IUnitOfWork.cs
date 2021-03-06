﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Galaxy.Data
{
    public interface IUnitOfWork
    {
        void BeginTransaction(bool unitWork=false);
  
        IDbContext DbContext { get; }

        bool IsUnitWork { get; }

        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);
        int ExecuteSqlCommand(string sql, params object[] parameters);

        Task<bool> InsertAsync<TEntity>(TEntity entity) where TEntity : class;

        bool Insert<TEntity>(TEntity entity) where TEntity : class;

        Task<bool> InsertAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

        bool Insert<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

        Task<bool> UpdateAsync<TEntity>(TEntity entity) where TEntity : class;

        bool Update<TEntity>(TEntity entity) where TEntity : class;

        Task<bool> CleanAsync<TEntity>(TEntity entity) where TEntity : class;

        bool Clean<TEntity>(TEntity entity) where TEntity : class;

        Task<bool> DeleteAsync<TEntity>(TEntity entity) where TEntity : class;

        bool Delete<TEntity>(TEntity entity) where TEntity : class;

        Task<bool> DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        bool Delete<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        Task<bool> CommitAsync();

        bool Commit();

        void Rollback();
    }
}
