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
    public partial interface ITableDetailsService:IBaseService<Log_TableDetails>
    {
        bool IsTableDetails(string tableId, string columnName);
        bool SaveTableDetails(Log_TableDetails entity);
        int SaveTableDetails(List<Log_TableDetails> list);
        bool UpdateTableDetailsPrimaryKey(long id, bool isPrimaryKey);
        bool UpdateTableDetailsColumnText(long id, string columnText, string remark);
        bool DeleteTableDetails();
        bool DeleteTableDetails(long id);
        bool DeleteTableDetails(Log_TableDetails entity);
        Log_TableDetails GetTableDetails(long id);
        List<Log_TableDetails> GetTableDetailsByTableID(string tableId);
        List<Log_TableDetails> GetTableDetailsByTableID(string tableId, bool isPrimaryKey);
    }
}
