using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Extend
{
    using CTMS.DbModels;
    using CTMS.DbContexts;
    using CTMS.IDAL.Extend;
    /// <summary>
    /// 
    /// </summary>
    public partial class LinkGroupDAL:BaseDAL<Extend_LinkGroup>,ILinkGroupDAL
    {
        public LinkGroupDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
