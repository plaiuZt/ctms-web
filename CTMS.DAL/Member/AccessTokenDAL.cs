using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Member
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Member;

    public partial class AccessTokenDAL : BaseDAL<Member_AccessToken>, IAccessTokenDAL
    {
        public AccessTokenDAL(CTMSContext dbContext) : base(dbContext)
        {
        }

    }
}
