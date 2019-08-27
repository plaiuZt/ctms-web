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
    public partial class AdvertisementDetailsDAL : BaseDAL<Extend_AdvertisementDetails>, IAdvertisementDetailsDAL
    {
        public AdvertisementDetailsDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
