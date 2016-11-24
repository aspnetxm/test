﻿/*******************************************************************************
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
    public interface IRepositoryBase<TEntity> where TEntity : class, new()
    {
        int Insert(TEntity entity);
        int Insert(List<TEntity> entitys);
        int Update(TEntity entity);
        int Delete(TEntity entity);
        int Delete(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(object keyValue);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> IQueryable();
        IQueryable<TEntity> IQueryable(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> FindList(string strSql);
        List<TEntity> FindList(string strSql, DbParameter[] dbParameter);
        List<TEntity> FindList(Pagination pagination);
        List<TEntity> FindList(Expression<Func<TEntity, bool>> predicate, Pagination pagination);
    }
}
