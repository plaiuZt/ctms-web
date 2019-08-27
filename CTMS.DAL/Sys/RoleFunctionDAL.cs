using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Sys
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Sys;

    public partial class RoleFunctionDAL : BaseDAL<Sys_RoleFunction>, IRoleFunctionDAL
    {
        public RoleFunctionDAL(CTMSContext dbContext) : base(dbContext)
        {
        }

    }
}
