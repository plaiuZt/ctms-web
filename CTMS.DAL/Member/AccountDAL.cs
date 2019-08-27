using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Member
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Member;

    public partial class AccountDAL:BaseDAL<Member_Account>,IAccountDAL
    {
        public AccountDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
        


    }
}
