using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Log
{
    using IDAL.Log;
    using CTMS.DbContexts;
    using CTMS.DbModels;

    /// <summary>
    /// 
    /// </summary>
    public partial class ErrorRecordDAL:BaseDAL<Log_ErrorRecord>,IErrorRecordDAL
    {
        public ErrorRecordDAL(CTMSContext dbContext) : base(dbContext)
        {
        }

    }
}
