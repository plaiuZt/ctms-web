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
    public partial interface ILoginRecordService:IBaseService<Log_LoginRecord>
    {
        bool SaveLoginRecord(Log_LoginRecord entity);
        bool DeleteLoginRecord(int systemId, string companyId, long id);
        bool DeleteLoginRecordAll(int systemId, string companyId);
        Log_LoginRecord GetLoginRecord(long id);
        Log_LoginRecord GetLoginRecord(int systemId, string companyId, long id);
        List<Log_LoginRecord> GetLoginRecordTop(int systemId, string companyId, int count);
        List<Log_LoginRecord> GetLoginRecordPaging(int systemId, string companyId, int pageId, int pageSize);
        List<Log_LoginRecord> SearchLoginRecord(int systemId, string companyId, string startTime, string endTime, string clientId, string keyword, int count);
        long CountLoginRecord(int systemId, string companyId);

    }
}
