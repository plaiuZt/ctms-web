using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Basics
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Basics;
    public partial class MediaMemberDAL:BaseDAL<Basics_MediaMember>,IMediaMemberDAL
    {
        public MediaMemberDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
