using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Service.Member
{
    using CTMS.DbModels;
    using CTMS.DbContexts;
    using CTMS.DbStoredProcedure;
    using CTMS.IService.Member;
    using CTMS.IDAL.Member;
    /// <summary>
    /// 
    /// </summary>
    public partial class PointRecordService:BaseService<Member_PointRecord>,IPointRecordService
    {
        private readonly IPointRecordDAL PointRecordDAL;
        private readonly CTMSContext CTMSContext;
        public PointRecordService(CTMSContext CTMSContext, IPointRecordDAL PointRecordDAL)
        {
            this.CTMSContext = CTMSContext;
            this.PointRecordDAL = PointRecordDAL;
            this.Dal = PointRecordDAL;
        }
        public override void SetDal()
        {
            Dal = PointRecordDAL;
        }

    }
}
