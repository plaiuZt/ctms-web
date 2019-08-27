using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Info
{
    using CTMS.DbModels;
    using CTMS.DbContexts;
    using CTMS.IDAL.Info;
    public partial class NoticeCategoryDAL:BaseDAL<Info_NoticeCategory>,INoticeCategoryDAL
    {
        public NoticeCategoryDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
