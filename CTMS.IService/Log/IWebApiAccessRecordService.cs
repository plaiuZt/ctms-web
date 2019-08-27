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
    public partial interface IWebApiAccessRecordService:IBaseService<Log_WebApiAccessRecord>
    {
        bool SaveSysWebApiAccessRecord(Log_WebApiAccessRecord entity);
        bool UpdateSysWebApiAccessRecordState(long id, string result, bool state);
        Log_WebApiAccessRecord GetSysWebApiAccessRecord(long id);
    }
}
