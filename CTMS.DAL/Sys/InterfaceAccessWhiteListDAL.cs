using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Sys
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Sys;

    public partial class InterfaceAccessWhiteListDAL:BaseDAL<Sys_InterfaceAccessWhiteList>,IInterfaceAccessWhiteListDAL
    {
        public InterfaceAccessWhiteListDAL(CTMSContext dbContext) : base(dbContext)
        {
        }

    }
}
