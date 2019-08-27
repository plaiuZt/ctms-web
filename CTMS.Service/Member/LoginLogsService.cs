using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Service.Member
{
    using CTMS.Common.Extension;
    using CTMS.Common.Json;
    using CTMS.Common.Security;
    using CTMS.Common.Time;
    using CTMS.DbContexts;
    using CTMS.DbStoredProcedure;
    using CTMS.DbModels;
    using CTMS.IService.Member;
    using CTMS.IDAL.Member;
    
    /// <summary>
    /// 
    /// </summary>
    public partial class LoginLogsService:BaseService<Member_LoginLogs>,ILoginLogsService
    {
        private readonly ILoginLogsDAL LoginLogsDAL;
        private readonly CTMSContext CTMSContext;
        public LoginLogsService(CTMSContext CTMSContext, ILoginLogsDAL LoginLogsDAL)
        {
            this.CTMSContext = CTMSContext;
            this.LoginLogsDAL = LoginLogsDAL;
            this.Dal = LoginLogsDAL;
        }
        public override void SetDal()
        {
            Dal = LoginLogsDAL;
        }



    }
}
