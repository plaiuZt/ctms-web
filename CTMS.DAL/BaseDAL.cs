using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CTMS.DAL
{
    using IDAL;
    using CTMS.DAL;
    using CTMS.DbContexts;
    using CTMS.Model;

    /// <summary>
    /// DAL操作实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class BaseDAL : IBaseDAL
    {
        private readonly CTMSContext dbContext;
        public BaseDAL(CTMSContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public CTMSContext DbEntities()
        {
            return dbContext;
        }
        public void Add<T>(T t) where T : class
        {
            dbContext.Add(t);
        }
        public void Add<T>(List<T> entitys) where T : class
        {
            dbContext.AddRange(entitys);
        }
        public void Update<T>(T t) where T : class
        {
            dbContext.Update(t);
        }
        public void Update<T>(List<T> entitys) where T : class
        {
            dbContext.UpdateRange(entitys);
        }
        public void Delete<T>(T t) where T : class
        {
            dbContext.Remove(t);
        }
        public void Delete<T>(Expression<Func<T, bool>> whereLambda) where T : class
        {
            var entitys = dbContext.Set<T>().Where(whereLambda).ToList();
            entitys.ForEach(m => dbContext.Remove(m));
        }
        public bool IsExists<T>(Expression<Func<T, bool>> whereLambda) where T : class
        {
            return dbContext.Set<T>().Where(whereLambda).Count() > 0;
        }
        public long Count<T>(Expression<Func<T, bool>> whereLambda) where T : class
        {
            return dbContext.Set<T>().Where(whereLambda).Count();
        }
        public string ExecuteCommand(string cmdText)
        {
            return dbContext.ExecuteScalar(cmdText);
        }
        public string ExecuteCommand(string cmdText, DbParameter[] sqlParameter)
        {
            return dbContext.ExecuteScalar(cmdText, sqlParameter);
        }
        //public T Find<T>(params object[] keyValues) where T : class
        //{
        //    return dbContext.Set<T>().Find(keyValues);
        //}
        public T Find<T>(Expression<Func<T, bool>> whereLambda) where T : class
        {
            return dbContext.Set<T>().Where(whereLambda).First();
        }
        public List<T> FindList<T>(string cmdText) where T : class
        {
            return dbContext.Orm.Ado.Query<T>(cmdText).ToList<T>();
        }
        public List<T> FindList<T>(string cmdText, DbParameter[] sqlParameter) where T : class
        {
            return dbContext.Orm.Ado.Query<T>(cmdText, sqlParameter).ToList<T>();
        }
        public IQueryable<T> FindList<T>() where T : class
        {
            return dbContext.Set<T>() as IQueryable<T>;
        }
        public IQueryable<T> FindList<T>(Expression<Func<T, bool>> whereLambda) where T : class
        {
            return dbContext.Set<T>().Where(whereLambda) as IQueryable<T>;
        }
        public IQueryable<T> FindList<T>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, bool>> orderLambda, bool isAsc) where T : class
        {
            if (isAsc)
                return dbContext.Set<T>().Where(whereLambda).OrderBy(orderLambda) as IQueryable<T>;
            else
                return dbContext.Set<T>().Where(whereLambda).OrderByDescending(orderLambda) as IQueryable<T>;
        }
        public IQueryable<T> FindListTop<T>(Expression<Func<T, bool>> whereLambda, int count) where T : class
        {
            return dbContext.Set<T>().Where(whereLambda).Take(count) as IQueryable<T>;
        }
        public IQueryable<T> FindListTop<T>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, bool>> orderLambda, bool isAsc, int count) where T : class
        {
            if (isAsc)
                return dbContext.Set<T>().Where(whereLambda).OrderBy(orderLambda).Take(count) as IQueryable<T>;
            else
                return dbContext.Set<T>().Where(whereLambda).OrderByDescending(orderLambda).Take(count) as IQueryable<T>;
        }
        public IQueryable<T> FindListTop<T>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> scalarLambda, int count) where T : class
        {
            return dbContext.Set<T>().Where(whereLambda).Select(scalarLambda).Take(count) as IQueryable<T>;
        }
        public IQueryable<T> FindListTop<T>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> scalarLambda, Expression<Func<T, bool>> orderLambda, bool isAsc, int count) where T : class
        {
            if (isAsc)
                return dbContext.Set<T>().Where(whereLambda).OrderBy(orderLambda).Select(scalarLambda).Take(count) as IQueryable<T>;
            else
                return dbContext.Set<T>().Where(whereLambda).OrderByDescending(orderLambda).Select(scalarLambda).Take(count) as IQueryable<T>;
        }

        public IQueryable<T> FindListPaging<T>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, bool>> orderLambda, bool isAsc, int pageIndex, int pageSize) where T : class
        {
            if (isAsc)
                return dbContext.Set<T>().Where(whereLambda).OrderBy(orderLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize) as IQueryable<T>;
            else
                return dbContext.Set<T>().Where(whereLambda).OrderByDescending(orderLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize) as IQueryable<T>;
        }
        public IQueryable<T> FindListPaging<T>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> scalarLambda, Expression<Func<T, bool>> orderLambda, bool isAsc, int pageIndex, int pageSize) where T : class
        {
            if (isAsc)
                return dbContext.Set<T>().Where(whereLambda).OrderBy(orderLambda).Select(scalarLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize) as IQueryable<T>;
            else
                return dbContext.Set<T>().Where(whereLambda).OrderByDescending(orderLambda).Select(scalarLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize) as IQueryable<T>;
        }
        public bool SaveChanges()
        {
            return dbContext.SaveChanges() > 0;
        }
    }
}
