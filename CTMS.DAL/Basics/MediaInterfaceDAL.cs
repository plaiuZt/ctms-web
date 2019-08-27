using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Basics
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Basics;
    public partial class MediaInterfaceDAL:BaseDAL<Basics_MediaInterface>,IMediaInterfaceDAL
    {
        public MediaInterfaceDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
