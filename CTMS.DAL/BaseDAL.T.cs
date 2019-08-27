using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CTMS.DAL
{
    using CTMS.Common.Enum;
    using CTMS.DbContexts;
    using FreeSql;
    using IDAL;

    /// <summary>
    /// DAL操作实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class BaseDAL<T> : IBaseDAL<T> where T : class, new()
    {
        private readonly CTMSContext dbContext;
        public BaseDAL(CTMSContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //public static DataType DbType = EnumHelper.StringConvertToEnum<DataType>(AppSettingsManager.Get("DbContexts:DbType"));
        public void Add(T t)
        {
            dbContext.Add(t);
        }
        public void Add(List<T> entitys)
        {
            dbContext.AddRange(entitys);
        }
        public void Update(T t)
        {
            dbContext.Update(t);
        }
        public void Update(List<T> entitys)
        {
            dbContext.UpdateRange(entitys);
        }
        public void Delete(T t)
        {
            dbContext.Set<T>().Remove(t);
        }
        public void Delete(Expression<Func<T, bool>> whereLambda)
        {
            var entitys = dbContext.Set<T>().Where(whereLambda).ToList();
            entitys.ForEach(m => dbContext.Remove(m));
        }   
        public bool IsExists(Expression<Func<T, bool>> whereLambda)
        {
            return dbContext.Set<T>().Where(whereLambda).Count() > 0;
        }
        public long Count(Expression<Func<T, bool>> whereLambda)
        {
            return dbContext.Set<T>().Where(whereLambda).Count();
        }
        //public T Find(params object[] keyValues)
        //{
        //    return dbContext.Set<T>().Find(keyValues);
        //}
        public T Find(Expression<Func<T, bool>> whereLambda)
        {
            return dbContext.Set<T>().Where(whereLambda).First();
        }
        public List<T> FindList(string cmdText)
        {
            return dbContext.Orm.Ado.Query<T>(cmdText).ToList<T>();
        }
        public List<T> FindList(string cmdText, DbParameter[] sqlParameter)
        {
            return dbContext.Orm.Ado.Query<T>(cmdText, sqlParameter).ToList<T>();
        }
        public IQueryable<T> FindList()
        {
            return dbContext.Set<T>() as IQueryable<T>;
        }
        public IQueryable<T> FindList(Expression<Func<T, bool>> whereLambda)
        {
            return dbContext.Set<T>().Where(whereLambda) as IQueryable<T>;
        }
        public IQueryable<T> FindList<type>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, type>> orderLambda, bool isAsc)
        {
            if(isAsc)
                return dbContext.Set<T>().Where(whereLambda).OrderBy(orderLambda) as IQueryable<T>;
            else
                return dbContext.Set<T>().Where(whereLambda).OrderByDescending(orderLambda) as IQueryable<T>;
        }
        public IQueryable<T> FindList<type>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> scalarLambda, Expression<Func<T, type>> orderLambda, bool isAsc)
        {
            if (isAsc)
                return dbContext.Set<T>().Where(whereLambda).OrderBy(orderLambda).Select(scalarLambda) as IQueryable<T>;
            else
                return dbContext.Set<T>().Where(whereLambda).OrderByDescending(orderLambda).Select(scalarLambda) as IQueryable<T>;
        }
        public IQueryable<T> FindListTop(Expression<Func<T, bool>> whereLambda, int count)
        {
            return dbContext.Set<T>().Where(whereLambda).Take(count) as IQueryable<T>;
        }
        public IQueryable<T> FindListTop<type>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, type>> orderLambda, bool isAsc, int count)
        {
            if (isAsc)
                return dbContext.Set<T>().Where(whereLambda).OrderBy(orderLambda).Take(count) as IQueryable<T>;
            else
                return dbContext.Set<T>().Where(whereLambda).OrderByDescending(orderLambda).Take(count) as IQueryable<T>;
        }
        public IQueryable<T> FindListTop<type>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> scalarLambda, int count)
        {
            return dbContext.Set<T>().Where(whereLambda).Select(scalarLambda).Take(count) as IQueryable<T>;
        }
        public IQueryable<T> FindListTop<type>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> scalarLambda, Expression<Func<T, type>> orderLambda, bool isAsc, int count)
        {
            if (isAsc)
                return dbContext.Set<T>().Where(whereLambda).OrderBy(orderLambda).Select(scalarLambda).Take(count) as IQueryable<T>;
            else
                return dbContext.Set<T>().Where(whereLambda).OrderByDescending(orderLambda).Select(scalarLambda).Take(count) as IQueryable<T>;
        }
        public IQueryable<T> FindListPaging<type>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, type>> orderLambda, bool isAsc, int pageIndex, int pageSize)
        {
            if (isAsc)
                return dbContext.Set<T>().Where(whereLambda).OrderBy(orderLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize) as IQueryable<T>;
            else
                return dbContext.Set<T>().Where(whereLambda).OrderByDescending(orderLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize) as IQueryable<T>;
        }
        public IQueryable<T> FindListPaging<type>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> scalarLambda, Expression<Func<T, type>> orderLambda, bool isAsc, int pageIndex, int pageSize)
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
