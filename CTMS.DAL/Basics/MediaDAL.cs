using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Basics
{
    using IDAL.Basics;
    using CTMS.DbModels;
    using CTMS.DbContexts;

    public partial class MediaDAL:BaseDAL<Basics_Media>,IMediaDAL
    {
        public MediaDAL(CTMSContext dbContext):base(dbContext)
        {
        }
    }
}
