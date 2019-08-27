using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTMS.Service.Log
{
    using CTMS.Common.Extension;
    using CTMS.Common.Json;
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IService.Log;
    using CTMS.IDAL.Log;

    /// <summary>
    /// 
    /// </summary>
    public partial class TableDetailsService:BaseService<Log_TableDetails>,ITableDetailsService
    {
        private readonly ITableDetailsDAL TableDetailsDAL;
        private readonly CTMSContext CTMSContext;
        public TableDetailsService(CTMSContext CTMSContext, ITableDetailsDAL TableDetailsDAL)
        {
            this.CTMSContext = CTMSContext;
            this.TableDetailsDAL = TableDetailsDAL;
            this.Dal = TableDetailsDAL;
        }
        public override void SetDal()
        {
            Dal = TableDetailsDAL;
        }

        public bool IsTableDetails(string tableId, string columnName)
        {
            return IsExists(m => m.TableID == tableId && m.ColumnName == columnName);
        }
        public bool SaveTableDetails(Log_TableDetails entity)
        {
            try
            {
                string tableId = entity.TableID;
                string columnName = entity.ColumnName;
                if (IsTableDetails(tableId, columnName))
                    throw new Exception("字段名已存在！");
                entity.CreateDate = DateTime.Now;
                return Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int SaveTableDetails(List<Log_TableDetails> list)
        {
            try
            {
                int result = 0;
                foreach (var m in list)
                {
                    string tableId = m.TableID;
                    string columnName = m.ColumnName;
                    if (!IsTableDetails(tableId, columnName))
                    {
                        m.CreateDate = DateTime.Now;
                        result = Add(m) ? result + 1 : result;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateTableDetailsPrimaryKey(long id, bool isPrimaryKey)
        {
            try
            {
                var entity = GetTableDetails(id);
                if (entity == null)
                    throw new Exception("table details id invalid！");
                string tableId = entity.TableID;

                int intnum = 0;
                var dbContext = new DAL.BaseDAL(CTMSContext);
                using (var db = dbContext.DbEntities())
                {
                    //using (var trans = db.Database.BeginTransaction())
                    //{
                    //    try
                    //    {
                    //        entity.IsPrimaryKey = isPrimaryKey;
                    //        dbContext.Update(entity);
                    //        List<string> arrPrimaryKey = new List<string>();
                    //        var lists = dbContext.FindList<Log_TableDetails>(m => m.TableID == tableId & m.IsPrimaryKey == true);
                    //        if (isPrimaryKey)
                    //        {
                    //            var entityDetails = dbContext.Find<Log_TableDetails>(m => m.ID == id);
                    //            arrPrimaryKey.Add(entityDetails.ColumnName);
                    //        }
                    //        var listDetails = from m in lists where !isPrimaryKey ? m.ID != id : true select m;
                    //        foreach (var m in listDetails)
                    //            arrPrimaryKey.Add(m.ColumnName);
                    //        var table = dbContext.Find<Log_Table>(m => m.TableID == tableId);

                    //        string strPrimaryKey = string.Empty;
                    //        foreach (var m in arrPrimaryKey.OrderBy(i => i).ToList())
                    //            strPrimaryKey += string.IsNullOrWhiteSpace(strPrimaryKey) ? m : string.Format(",{0}", m);
                    //        table.PrimaryKey = strPrimaryKey;

                    //        dbContext.Update(table);

                    //        intnum = db.SaveChanges();
                    //        trans.Commit();
                    //    }
                    //    catch (Exception)
                    //    {
                    //        trans.Rollback();
                    //    }

                    //    return intnum > 0;
                    //}
                    db.Orm.Transaction(() =>
                    {
                        entity.IsPrimaryKey = isPrimaryKey;
                        dbContext.Update(entity);
                        List<string> arrPrimaryKey = new List<string>();
                        var lists = dbContext.FindList<Log_TableDetails>(m => m.TableID == tableId & m.IsPrimaryKey == true);
                        if (isPrimaryKey)
                        {
                            var entityDetails = dbContext.Find<Log_TableDetails>(m => m.ID == id);
                            arrPrimaryKey.Add(entityDetails.ColumnName);
                        }
                        var listDetails = from m in lists where !isPrimaryKey ? m.ID != id : true select m;
                        foreach (var m in listDetails)
                            arrPrimaryKey.Add(m.ColumnName);
                        var table = dbContext.Find<Log_Table>(m => m.TableID == tableId);

                        string strPrimaryKey = string.Empty;
                        foreach (var m in arrPrimaryKey.OrderBy(i => i).ToList())
                            strPrimaryKey += string.IsNullOrWhiteSpace(strPrimaryKey) ? m : string.Format(",{0}", m);
                        table.PrimaryKey = strPrimaryKey;

                        dbContext.Update(table);

                        intnum = db.SaveChanges();
                        //trans.Commit();
                    });
                    return intnum > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateTableDetailsColumnText(long id, string columnText, string remark)
        {
            try
            {
                var entity = GetTableDetails(id);
                if (entity == null)
                    throw new Exception("table details id invalid！");
                entity.ColumnText = columnText;
                entity.Remark = remark;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteTableDetails()
        {
            try
            {
                var expression = ExtLinq.True<Log_TableDetails>();
                expression = expression.And(m => true);
                return Delete(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteTableDetails(long id)
        {
            try
            {
                var expression = ExtLinq.True<Log_TableDetails>();
                expression = expression.And(m => m.ID == id);
                return Delete(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteTableDetails(Log_TableDetails entity)
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
        public Log_TableDetails GetTableDetails(long id)
        {
            try
            {
                return Find(m => m.ID == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Log_TableDetails> GetTableDetailsByTableID(string tableId)
        {
            try
            {
                return FindList(m => m.TableID == tableId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Log_TableDetails> GetTableDetailsByTableID(string tableId, bool isPrimaryKey)
        {
            try
            {
                return FindList(m => m.TableID == tableId & m.IsPrimaryKey == isPrimaryKey).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
