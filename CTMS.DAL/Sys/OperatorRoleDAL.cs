using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Sys
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Sys;

    public partial class OperatorRoleDAL : BaseDAL<Sys_OperatorRole>, IOperatorRoleDAL
    {
        public OperatorRoleDAL(CTMSContext dbContext) : base(dbContext)
        {
        }

    }
}
