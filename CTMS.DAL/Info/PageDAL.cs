using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Info
{
    using CTMS.DbModels;
    using CTMS.DbContexts;
    using CTMS.IDAL.Info;
    public partial class PageDAL:BaseDAL<Info_Page>,IPageDAL
    {
        public PageDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
