using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Member
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Member;
    public partial class RefreshTokenDAL:BaseDAL<Member_RefreshToken>
    {
        public RefreshTokenDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
