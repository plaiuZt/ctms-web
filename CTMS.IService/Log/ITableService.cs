using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Log
{
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    /// <summary>
    /// 
    /// </summary>
    public partial interface ITableService:IBaseService<Log_Table>
    {
        bool SaveTable(Log_Table entity);
        int SaveTable(Log_Table entity, List<Log_TableDetails> list);
        bool UpdateTableBusinessName(string tableId, string businessName, string remark);
        bool DeleteTable();
        bool DeleteTable(string tableId);
        bool DeleteTable(Log_Table entity);
        Log_Table GetTable(string tableId);
        Log_Table GetTableByName(string tableName);
        List<Log_Table> GetTableTop(int count);
        List<Log_Table> GetTablePaging(int pageId, int pageSize, out long totalRows);
        List<Log_Table> SearchTable(string keyword);

    }
}
