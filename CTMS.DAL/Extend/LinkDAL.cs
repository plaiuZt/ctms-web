using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Extend
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.IDAL.Extend;
    /// <summary>
    /// 
    /// </summary>
    public partial class LinkDAL:BaseDAL<Extend_Link>,ILinkDAL
    {
        public LinkDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
