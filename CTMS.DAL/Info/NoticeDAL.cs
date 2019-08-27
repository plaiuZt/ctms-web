using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Info
{
    using CTMS.DbModels;
    using CTMS.DbContexts;
    using CTMS.IDAL.Info;
    public partial class NoticeDAL:BaseDAL<Info_Notice>,INoticeDAL
    {
        public NoticeDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
