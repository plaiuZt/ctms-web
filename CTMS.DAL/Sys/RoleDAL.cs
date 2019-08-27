using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Sys
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Sys;

    public partial class RoleDAL : BaseDAL<Sys_Role>, IRoleDAL
    {
        public RoleDAL(CTMSContext dbContext) : base(dbContext)
        {
        }

    }
}
