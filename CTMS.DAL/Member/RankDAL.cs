using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Member
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Member;

    public partial class RankDAL:BaseDAL<Member_Rank>,IRankDAL
    {
        public RankDAL(CTMSContext dbContext) : base(dbContext)
        {
        }

    }
}
