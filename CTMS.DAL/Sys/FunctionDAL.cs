using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Sys
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Sys;

    public partial class FunctionDAL:BaseDAL<Sys_Function>,IFunctionDAL
    {
        public FunctionDAL(CTMSContext dbContext) : base(dbContext)
        {
        }

    }
}
