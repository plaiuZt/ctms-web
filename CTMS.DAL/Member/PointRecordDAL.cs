using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Member
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Member;

    public partial class PointRecordDAL:BaseDAL<Member_PointRecord>,IPointRecordDAL
    {
        public PointRecordDAL(CTMSContext dbContext) : base(dbContext)
        {
        }

    }
}
