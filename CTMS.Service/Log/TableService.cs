using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Service.Log
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IService.Log;
    using CTMS.IDAL.Log;
    using CTMS.Common.Extension;
    using CTMS.Common.Json;

    /// <summary>
    /// 
    /// </summary>
    public partial class TableService:BaseService<Log_Table>,ITableService
    {
        private readonly ITableDAL TableDAL;
        private readonly CTMSContext CTMSContext;
        public TableService(CTMSContext CTMSContext, ITableDAL TableDAL)
        {
            this.CTMSContext = CTMSContext;
            this.TableDAL = TableDAL;
            this.Dal = TableDAL;
        }
        public override void SetDal()
        {
            Dal = TableDAL;
        }

        private bool IsTableByName(string tableName)
        {
            return IsExists(m => m.TableName == tableName);
        }
        public bool SaveTable(Log_Table entity)
        {
            try
            {
                string tableName = entity.TableName;
                if (IsTableByName(tableName))
                    throw new Exception("表名已存在！");
                entity.CreateDate = DateTime.Now;
                return Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int SaveTable(Log_Table entity, List<Log_TableDetails> list)
        {
            try
            {
                try
                {
                    string tableName = entity.TableName;
                    if (IsTableByName(tableName))
                        throw new Exception("表名已存在！");
                    int intnum = 0;
                    var dbContext = new DAL.BaseDAL(CTMSContext);
                    using (var db = dbContext.DbEntities())
                    {
                        //    using (var trans = db.Database.BeginTransaction())
                        //    {
                        //        try
                        //        {
                        //            entity.CreateDate = DateTime.Now;
                        //            db.Add(entity);
                        //            foreach (var m in list)
                        //            {
                        //                m.CreateDate = DateTime.Now;
                        //                db.Add(m);
                        //            }
                        //            intnum = db.SaveChanges();
                        //            trans.Commit();
                        //        }
                        //        catch (Exception)
                        //        {
                        //            trans.Rollback();
                        //        }
                        //        return intnum;
                        //    }

                        db.Orm.Transaction(()=>
                        {
                            entity.CreateDate = DateTime.Now;
                            db.Add(entity);
                            foreach (var m in list)
                            {
                                m.CreateDate = DateTime.Now;
                                db.Add(m);
                            }
                            intnum = db.SaveChanges();
                        });
                        return intnum;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateTableBusinessName(string tableId, string businessName, string remark)
        {
            try
            {
                var entity = GetTable(tableId);
                if (entity == null)
                    throw new Exception("table id invalid！");
                entity.BusinessName = businessName;
                entity.Remark = remark;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteTable()
        {
            try
            {
                var expression = ExtLinq.True<Log_Table>();
                expression = expression.And(m => true);
                return Delete(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteTable(string tableId)
        {
            try
            {
                var expression = ExtLinq.True<Log_Table>();
                expression = expression.And(m => m.TableID == tableId);
                return Delete(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteTable(Log_Table entity)
        {
            try
            {
                return Delete(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Log_Table GetTable(string tableId)
        {
            try
            {
                return Find(m => m.TableID == tableId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Log_Table GetTableByName(string tableName)
        {
            try
            {
                return Find(m => m.TableName == tableName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Log_Table> GetTableTop(int count)
        {
            try
            {
                var expression = ExtLinq.True<Log_Table>();
                expression = expression.And(m => true);
                var lists = FindListTop(expression, m => m.TableID, false, count);
                return lists == null ? null : lists.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Log_Table> GetTablePaging(int pageId, int pageSize, out long totalRows)
        {
            try
            {
                var expression = ExtLinq.True<Log_Table>();
                expression = expression.And(m => true);
                totalRows = Count(expression);
                var lists = FindListPaging(expression, m => m.TableName, true, pageId, pageSize);
                return lists == null ? null : lists.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Log_Table> SearchTable(string keyword)
        {
            try
            {
                var expression = ExtLinq.True<Log_Table>();
                expression = expression.And(m => m.TableName.Contains(keyword));
                var lists = FindList(expression, m => m.TableName, true);
                return lists == null ? null : lists.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
