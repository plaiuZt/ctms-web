using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Info
{
    using CTMS.DbModels;
    using CTMS.DbContexts;
    using CTMS.IDAL.Info;
    /// <summary>
    /// 
    /// </summary>
    public partial class ArticeDAL:BaseDAL<Info_Artice>,IArticeDAL
    {
        public ArticeDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
