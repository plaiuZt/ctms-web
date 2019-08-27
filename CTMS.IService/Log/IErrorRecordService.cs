using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Log
{
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    public partial interface IErrorRecordService:IBaseService<Log_ErrorRecord>
    {
        bool SaveErrorRecord(Log_ErrorRecord entity);
    }
}
