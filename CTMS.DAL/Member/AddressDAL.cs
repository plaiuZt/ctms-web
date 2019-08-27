using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Member
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Member;

    public partial class AddressDAL:BaseDAL<Member_Address>,IAddressDAL
    {
        public AddressDAL(CTMSContext dbContext) : base(dbContext)
        {
        }


    }
}
