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
    public partial interface IVisitorRecordService:IBaseService<Log_VisitorRecord>
    {
        bool SaveVisitorRecord(Log_VisitorRecord entity);


    }
}
