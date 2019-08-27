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
    public partial class AmountRecordService:BaseService<Member_AmountRecord>,IAmountRecordService
    {
        private readonly IAmountRecordDAL AmountRecordDAL;
        private readonly CTMSContext CTMSContext;
        public AmountRecordService(CTMSContext CTMSContext, IAmountRecordDAL AmountRecordDAL)
        {
            this.CTMSContext = CTMSContext;
            this.AmountRecordDAL = AmountRecordDAL;
            this.Dal = AmountRecordDAL;
        }
        public override void SetDal()
        {
            Dal = AmountRecordDAL;
        }

    }
}
