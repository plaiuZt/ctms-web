using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Member
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Member;

    public partial class AmountRecordDAL:BaseDAL<Member_AmountRecord>, IAmountRecordDAL
    {
        public AmountRecordDAL(CTMSContext dbContext) : base(dbContext)
        {
        }


    }
}
