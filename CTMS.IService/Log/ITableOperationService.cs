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
    public partial interface ITableOperationService:IBaseService<Log_TableOperation>
    {
        bool SaveTableOperation(Log_TableOperation entity);
        bool SaveTableOperation(Log_TableOperation entity, out long tableOperationID);
        bool UpdateTableOperationState(long id, bool state);
        bool DeleteTableOperation(long id);
        Log_TableOperation GetTableOperation(long id);
        List<Log_TableOperation> GetTableOperationTop(int count);
        List<Log_TableOperation> GetTableOperationPaging(int pageId, int pageSize, out long totalRows);
        List<Log_TableOperation> SearchTableOperation(string startTime, string endTime, string clientId, string classId,string keyword);


    }
}
