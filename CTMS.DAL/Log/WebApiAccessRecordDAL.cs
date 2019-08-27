using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Log
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Log;
    /// <summary>
    /// 
    /// </summary>
    public partial class WebApiAccessRecordDAL:BaseDAL<Log_WebApiAccessRecord>,IWebApiAccessRecordDAL
    {
        public WebApiAccessRecordDAL(CTMSContext dbContext) : base(dbContext)
        {
        }

    }
}
