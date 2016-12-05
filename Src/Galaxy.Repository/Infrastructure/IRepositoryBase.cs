using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Galaxy.DTO.CommonModule;

namespace Galaxy.Repository.Infrastructure
{
    public interface IRepositoryBase<TEntity> where TEntity : class, new()
    {
        //bool Insert(TEntity entity);
        //Task<bool> InsertAsync(TEntity entity);
        //bool Insert(List<TEntity> entitys);
        //Task<bool> InsertAsync(List<TEntity> entitys);
        //bool Update(TEntity entity);
        //Task<bool> UpdateAsync(TEntity entity);
        //bool Delete(TEntity entity);
        //Task<bool> DeleteAsync(TEntity entity);
        //bool Delete(Expression<Func<TEntity, bool>> predicate);
        //Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate);

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
