using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Member
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Member;
    /// <summary>
    /// 
    /// </summary>
    public partial class LoginLogsDAL:BaseDAL<Member_LoginLogs>,ILoginLogsDAL
    {
        public LoginLogsDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
