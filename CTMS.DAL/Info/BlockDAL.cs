using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Info
{
    using CTMS.DbModels;
    using CTMS.DbContexts;
    using CTMS.IDAL.Info;
    public partial class BlockDAL:BaseDAL<Info_Block>,IBlockDAL
    {
        public BlockDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
