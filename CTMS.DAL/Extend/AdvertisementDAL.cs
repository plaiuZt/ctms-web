using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Extend
{
    using CTMS.DbModels;
    using CTMS.IDAL.Extend;
    using CTMS.DbContexts;

    /// <summary>
    /// 
    /// </summary>
    public partial class AdvertisementDAL:BaseDAL<Extend_Advertisement>,IAdvertisementDAL
    {
        public AdvertisementDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
