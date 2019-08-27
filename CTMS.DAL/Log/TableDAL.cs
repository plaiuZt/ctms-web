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
    public partial class TableDAL:BaseDAL<Log_Table>,ITableDAL
    {
        public TableDAL(CTMSContext dbContext) : base(dbContext)
        {
        }


    }
}
