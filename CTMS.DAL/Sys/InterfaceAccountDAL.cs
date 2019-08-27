using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Sys
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Sys;

    public partial class InterfaceAccountDAL:BaseDAL<Sys_InterfaceAccount>,IInterfaceAccountDAL
    {
        public InterfaceAccountDAL(CTMSContext dbContext) : base(dbContext)
        {
        }

    }
}
