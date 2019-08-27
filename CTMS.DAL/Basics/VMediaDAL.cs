using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Basics
{
    using IDAL.Basics;
    using CTMS.DbViews;
    using CTMS.DbContexts;

    public partial class VMediaDAL: BaseDAL<V_Basics_Media>, IVMediaDAL
    {
        public VMediaDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
