﻿using System;
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
    public partial class TableOperationDAL:BaseDAL<Log_TableOperation>,ITableOperationDAL
    {
        public TableOperationDAL(CTMSContext dbContext) : base(dbContext)
        {
        }

    }
}
