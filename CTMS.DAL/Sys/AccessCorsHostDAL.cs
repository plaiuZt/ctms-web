using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Sys
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Sys;

    public partial class AccessCorsHostDAL : BaseDAL<Sys_AccessCorsHost>, IAccessCorsHostDAL
    {
        public AccessCorsHostDAL(CTMSContext dbContext) : base(dbContext)
        {
        }

    }
}
