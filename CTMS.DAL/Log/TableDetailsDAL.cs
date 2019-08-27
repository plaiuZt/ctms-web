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
    public partial class TableDetailsDAL:BaseDAL<Log_TableDetails>,ITableDetailsDAL
    {
        public TableDetailsDAL(CTMSContext dbContext) : base(dbContext)
        {
        }

    }
}
