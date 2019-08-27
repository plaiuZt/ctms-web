using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Sys
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Sys;

    public partial class ConfigDAL:BaseDAL<Sys_Config>,IConfigDAL
    {
        public ConfigDAL(CTMSContext dbContext) : base(dbContext)
        {
        }


    }
}
