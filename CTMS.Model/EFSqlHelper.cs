using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CTMS.DbContexts;

namespace CTMS.Model
{
    /// <summary>
    /// EF Core SQL操作类
    /// 
    /// 
    /// 
    /// </summary>
    public static class EFSqlHelper
    {

        #region 执行新增、修改、删除动作返回 int
        /// <summary>
        /// 执行SQL语句、存储过程返回影响的行数 注：主要用于新增、修改、删除操作返回影响行数
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdType">链接类型</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <param name="sqlParams">参数 SqlParameter集合</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(this CTMSContext db, CommandType cmdType, string cmdText, DbParameter[] sqlParams)
        {
            try
            {
                return db.Orm.Ado.ExecuteNonQuery(cmdType,cmdText,sqlParams);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 执行SQL语句不带参数
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(this CTMSContext db, string cmdText)
        {
            try
            {
                return db.ExecuteNonQuery(CommandType.Text, cmdText, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 执行SQL语句带参数
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <param name="sqlParams">参数 SqlParameter集合</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(this CTMSContext db, string cmdText, DbParameter[] sqlParams)
        {
            try
            {
                return db.ExecuteNonQuery(CommandType.Text, cmdText, sqlParams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 执行存储过程不带参数
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <returns></returns>
        public static int ExecuteNonQueryPro(this CTMSContext db, string cmdText)
        {
            try
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, cmdText, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 执行存储过程带参数
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <param name="sqlParams">参数 SqlParameter集合</param>
        /// <returns></returns>
        public static int ExecuteNonQueryPro(this CTMSContext db, string cmdText, DbParameter[] sqlParams)
        {
            try
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, cmdText, sqlParams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region 执行查询第一行第一列数据返回 string
        /// <summary>
        /// 执行SQL语句、存储过程返回第一行第一列数据 主要用于统计、计算
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdType">链接类型</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <param name="sqlParams">参数 SqlParameter集合</param>
        /// <returns></returns>
        public static string ExecuteScalar(this CTMSContext db, CommandType cmdType, string cmdText, DbParameter[] sqlParams)
        {
            try
            {
                string result = string.Empty;
                var scalarResult = db.Orm.Ado.ExecuteScalar(cmdType,cmdText,sqlParams);
                if (scalarResult != null)
                    result = scalarResult.ToString();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 执行SQL语句不带参数
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <returns></returns>
        public static string ExecuteScalar(this CTMSContext db, string cmdText)
        {
            try
            {
                return db.ExecuteScalar(CommandType.Text, cmdText, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 执行SQL语句带参数
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <param name="sqlParams">参数 SqlParameter集合</param>
        /// <returns></returns>
        public static string ExecuteScalar(this CTMSContext db, string cmdText, DbParameter[] sqlParams)
        {
            try
            {
                return db.ExecuteScalar(CommandType.Text, cmdText, sqlParams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 执行存储过程不带参数
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <returns></returns>
        public static string ExecuteScalarPro(this CTMSContext db, string cmdText)
        {
            try
            {
                return db.ExecuteScalar(CommandType.StoredProcedure, cmdText, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 执行存储过程带参数
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <param name="sqlParams">参数 SqlParameter集合</param>
        /// <returns></returns>
        public static string ExecuteScalarPro(this CTMSContext db, string cmdText, DbParameter[] sqlParams)
        {
            try
            {
                return db.ExecuteScalar(CommandType.StoredProcedure, cmdText, sqlParams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region 执行查询数据集返回 DbDataReader、ArrayList
        /// <summary>
        /// 执行SQL语句、存储过程查询数据集合返回 ArrayList 主要用于数据集合查询
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdType">链接类型</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <param name="sqlParams">参数 SqlParameter集合</param>
        /// <returns></returns>
        public static ArrayList ExecuteReader(this CTMSContext db, CommandType cmdType, string cmdText, DbParameter[] sqlParams)
        {
            try
            {
                var data = new ArrayList();
                db.Orm.Ado.ExecuteReader(dr => 
                {
                    var columnSchema = dr.GetColumnSchema();
                    
                    var item = new Dictionary<string, object>();
                    foreach (var kv in columnSchema)
                    {
                        if (kv.ColumnOrdinal.HasValue)
                        {
                            var itemVal = dr.GetValue(kv.ColumnOrdinal.Value);
                            item.Add(kv.ColumnName, itemVal.GetType() != typeof(DBNull) ? itemVal : "");
                        }
                    }
                    data.Add(item);
                    //dr.Close();
                    //dr.Dispose();
                },cmdType,cmdText,sqlParams);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 不带参数的文本查询
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <returns></returns>
        public static ArrayList ExecuteReader(this CTMSContext db, string cmdText)
        {
            try
            {
                return db.ExecuteReader(CommandType.Text, cmdText, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 带参数的文本查询
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <param name="sqlParams">参数 SqlParameter集合</param>
        /// <returns></returns>
        public static ArrayList ExecuteReader(this CTMSContext db, string cmdText, DbParameter[] sqlParams)
        {
            try
            {
                return db.ExecuteReader(CommandType.Text, cmdText, sqlParams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 不带参数的存储过程
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <returns></returns>
        public static ArrayList ExecuteReaderPro(this CTMSContext db, string cmdText)
        {
            try
            {
                return db.ExecuteReader(CommandType.StoredProcedure, cmdText, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 带参数的存储过程
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <param name="sqlParams">参数 SqlParameter集合</param>
        /// <returns></returns>
        public static ArrayList ExecuteReaderPro(this CTMSContext db, string cmdText, DbParameter[] sqlParams)
        {
            try
            {
                return db.ExecuteReader(CommandType.StoredProcedure, cmdText, sqlParams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region 创建事务执行SQL语句
        /// <summary>
        /// 创建事务执行SQL语句 主要用于多表新增、修改、删除操作
        /// 调用说明：
        ///     ArrayList cmdTextList = new ArrayList();
        ///     cmdTextList.Add("insert into Ld_Sys_Test (Name,CreateDate) values ('李白',getdate())");
        ///     cmdTextList.Add("insert into Ld_Sys_Staff (id,StaffId,StaffName) values (15,'1234567890','李白')");
        ///     cmdTextList.Add("declare @errCode int,@errMsg nvarchar(400) exec SP_Add_Sys_Test '张长',@errCode output,@errMsg output");
        ///     db.ExecuteCommandTrans(cmdTextList);
        /// 
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdTextList">SQL语句数组列表</param>
        public static void ExecuteCommandTrans(this CTMSContext db, ArrayList cmdTextList)
        {
            try
            {
                db.Orm.Ado.Transaction(() => {
                    foreach (string varCmdText in cmdTextList)
                    {
                        db.Orm.Ado.ExecuteNonQuery(varCmdText);
                    }
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region 异步执行新增、修改、删除动作返回 Task<int>
        /// <summary>
        /// 异步执行SQL语句、存储过程返回影响的行数 注：主要用于新增、修改、删除操作返回影响行数
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdType">链接类型</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <param name="sqlParams">参数 SqlParameter集合</param>
        /// <returns></returns>
        public async static Task<int> ExecuteNonQueryAsync(this CTMSContext db, CommandType cmdType, string cmdText, DbParameter[] sqlParams)
        {
            try
            {
                return await db.Orm.Ado.ExecuteNonQueryAsync(cmdType, cmdText, sqlParams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 不带参数的文本查询
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <returns></returns>
        public async static Task<int> ExecuteNonQueryAsync(this CTMSContext db, string cmdText)
        {
            try
            {
                return await db.ExecuteNonQueryAsync(CommandType.Text, cmdText, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 带参数的文本查询
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <param name="sqlParams">参数 SqlParameter集合</param>
        /// <returns></returns>
        public async static Task<int> ExecuteNonQueryAsync(this CTMSContext db, string cmdText, DbParameter[] sqlParams)
        {
            try
            {
                return await db.ExecuteNonQueryAsync(CommandType.Text, cmdText, sqlParams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 不带参数的存储过程
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <returns></returns>
        public async static Task<int> ExecuteNonQueryProAsync(this CTMSContext db, string cmdText)
        {
            try
            {
                return await db.ExecuteNonQueryAsync(CommandType.StoredProcedure, cmdText, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 带参数的存储过程
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <param name="sqlParams">参数 SqlParameter集合</param>
        /// <returns></returns>
        public async static Task<int> ExecuteNonQueryProAsync(this CTMSContext db, string cmdText, DbParameter[] sqlParams)
        {
            try
            {
                return await db.ExecuteNonQueryAsync(CommandType.StoredProcedure, cmdText, sqlParams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region 异步执行查询第一行第一列数据返回 Task<string>
        /// <summary>
        /// 异步执行SQL语句、存储过程返回第一行第一列数据 主要用于统计、计算
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdType">链接类型</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <param name="sqlParams">参数 SqlParameter集合</param>
        /// <returns></returns>
        public async static Task<string> ExecuteScalarAsync(this CTMSContext db, CommandType cmdType, string cmdText, DbParameter[] sqlParams)
        {
            try
            {
                string result = string.Empty;
                var scalarResult = await db.Orm.Ado.ExecuteScalarAsync(cmdType,cmdText,sqlParams);
                if (scalarResult != null)
                    result = scalarResult.ToString();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 不带参数的文本查询
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <returns></returns>
        public async static Task<string> ExecuteScalarAsync(this CTMSContext db, string cmdText)
        {
            try
            {
                return await db.ExecuteScalarAsync(CommandType.Text, cmdText, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 带参数的文本查询
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <param name="sqlParams">参数 SqlParameter集合</param>
        /// <returns></returns>
        public async static Task<string> ExecuteScalarAsync(this CTMSContext db, string cmdText, DbParameter[] sqlParams)
        {
            try
            {
                return await db.ExecuteScalarAsync(CommandType.Text, cmdText, sqlParams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 不带参数的存储过程
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <returns></returns>
        public async static Task<string> ExecuteScalarProAsync(this CTMSContext db, string cmdText)
        {
            try
            {
                return await db.ExecuteScalarAsync(CommandType.StoredProcedure, cmdText, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 带参数的存储过程
        /// </summary>
        /// <param name="db">链接数据库EF DbContext对象</param>
        /// <param name="cmdText">SQL语句、存储过程名称</param>
        /// <param name="sqlParams">参数 SqlParameter集合</param>
        /// <returns></returns>
        public async static Task<string> ExecuteScalarProAsync(this CTMSContext db, string cmdText, DbParameter[] sqlParams)
        {
            try
            {
                return await db.ExecuteScalarAsync(CommandType.StoredProcedure, cmdText, sqlParams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region 异步执行查询数据集返回 DbDataReader、Task<ArrayList>
        ///// <summary>
        ///// 异步执行SQL语句、存储过程查询数据集合及空值处理返回ArrayList。主要用于数据集合查询
        ///// </summary>
        ///// <param name="db">链接数据库EF DbContext对象</param>
        ///// <param name="cmdType">链接类型</param>
        ///// <param name="cmdText">SQL语句、存储过程名称</param>
        ///// <param name="sqlParams">参数 SqlParameter集合</param>
        ///// <returns></returns>
        //public async static Task<ArrayList> ExecuteReaderAsync(this CTMSContext db, CommandType cmdType, string cmdText, SqlParameter[] sqlParams)
        //{
        //    try
        //    {
        //        var connection = db.Database.GetDbConnection();
        //        using (var cmd = connection.CreateCommand())
        //        {
        //            await db.Database.OpenConnectionAsync();
        //            cmd.CommandText = cmdText;
        //            cmd.CommandType = cmdType;
        //            cmd.Parameters.Clear();
        //            if (sqlParams != null)
        //            {
        //                cmd.Parameters.AddRange(sqlParams);
        //            }
        //            var dr = await cmd.ExecuteReaderAsync();
        //            var columnSchema = dr.GetColumnSchema();
        //            var data = new ArrayList();
        //            while (await dr.ReadAsync())
        //            {
        //                var item = new Dictionary<string, object>();
        //                foreach (var kv in columnSchema)
        //                {
        //                    if (kv.ColumnOrdinal.HasValue)
        //                    {
        //                        var itemVal = dr.GetValue(kv.ColumnOrdinal.Value);
        //                        item.Add(kv.ColumnName, itemVal.GetType() != typeof(DBNull) ? itemVal : "");
        //                    }
        //                }
        //                data.Add(item);
        //            }
        //            dr.Close();
        //            dr.Dispose();
        //            //var a = sqlParams[1].Value;//测试回调参数值
        //            cmd.Parameters.Clear();
        //            return data;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        ///// <summary>
        ///// 不带参数的文本查询
        ///// </summary>
        ///// <param name="db">链接数据库EF DbContext对象</param>
        ///// <param name="cmdText">SQL语句、存储过程名称</param>
        ///// <returns></returns>
        //public async static Task<ArrayList> ExecuteReaderAsync(this CTMSContext db, string cmdText)
        //{
        //    try
        //    {
        //        return await db.ExecuteReaderAsync(CommandType.Text, cmdText, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        ///// <summary>
        ///// 带参数的文本查询
        ///// </summary>
        ///// <param name="db">链接数据库EF DbContext对象</param>
        ///// <param name="cmdText">SQL语句、存储过程名称</param>
        ///// <param name="sqlParams">参数 SqlParameter集合</param>
        ///// <returns></returns>
        //public async static Task<ArrayList> ExecuteReaderAsync(this CTMSContext db, string cmdText, SqlParameter[] sqlParams)
        //{
        //    try
        //    {
        //        return await db.ExecuteReaderAsync(CommandType.Text, cmdText, sqlParams);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        ///// <summary>
        ///// 不带参数的存储过程
        ///// </summary>
        ///// <param name="db">链接数据库EF DbContext对象</param>
        ///// <param name="cmdText">SQL语句、存储过程名称</param>
        ///// <returns></returns>
        //public async static Task<ArrayList> ExecuteReaderProAsync(this CTMSContext db, string cmdText)
        //{
        //    try
        //    {
        //        return await db.ExecuteReaderAsync(CommandType.StoredProcedure, cmdText, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        ///// <summary>
        ///// 带参数的存储过程
        ///// </summary>
        ///// <param name="db">链接数据库EF DbContext对象</param>
        ///// <param name="cmdText">SQL语句、存储过程名称</param>
        ///// <param name="sqlParams">参数 SqlParameter集合</param>
        ///// <returns></returns>
        //public async static Task<ArrayList> ExecuteReaderProAsync(this CTMSContext db, string cmdText, SqlParameter[] sqlParams)
        //{
        //    try
        //    {
        //        return await db.ExecuteReaderAsync(CommandType.StoredProcedure, cmdText, sqlParams);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        
        #endregion

    }
}
