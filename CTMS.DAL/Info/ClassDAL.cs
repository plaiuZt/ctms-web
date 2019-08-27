using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Info
{
    using CTMS.DbModels;
    using CTMS.DbContexts;
    using CTMS.IDAL.Info;
    public partial class ClassDAL:BaseDAL<Info_Class>,IClassDAL
    {
        public ClassDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
