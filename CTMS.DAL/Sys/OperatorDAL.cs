using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Sys
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Sys;

    public partial class OperatorDAL: BaseDAL<Sys_Operator>, IOperatorDAL
    {
        public OperatorDAL(CTMSContext dbContext) : base(dbContext)
        {
        }

    }
}
