using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Sys
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Sys;

    public partial class VersionDAL : BaseDAL<Sys_Version>, IVersionDAL
    {
        public VersionDAL(CTMSContext dbContext) : base(dbContext)
        {
        }

    }
}
