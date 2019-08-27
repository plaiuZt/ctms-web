using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Sys
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Sys;

    public partial class CodeDAL:BaseDAL<Sys_Code>, ICodeDAL
    {
        public CodeDAL(CTMSContext dbContext) : base(dbContext)
        {
        }




    }
}
