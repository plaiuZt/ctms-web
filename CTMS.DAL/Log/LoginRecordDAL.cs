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
    public partial class LoginRecordDAL:BaseDAL<Log_LoginRecord>,ILoginRecordDAL
    {
        public LoginRecordDAL(CTMSContext dbContext) : base(dbContext)
        {
        }

    }
}
