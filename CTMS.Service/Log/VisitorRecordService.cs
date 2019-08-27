using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Service.Log
{
    using CTMS.Common.Json;
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IService.Log;
    using CTMS.IDAL.Log;
    /// <summary>
    /// 
    /// </summary>
    public partial class VisitorRecordService:BaseService<Log_VisitorRecord>,IVisitorRecordService
    {
        private readonly IVisitorRecordDAL VisitorRecordDAL;
        private readonly CTMSContext CTMSContext;
        public VisitorRecordService(CTMSContext CTMSContext, IVisitorRecordDAL VisitorRecordDAL)
        {
            this.CTMSContext = CTMSContext;
            this.VisitorRecordDAL = VisitorRecordDAL;
            this.Dal = VisitorRecordDAL;
        }
        public override void SetDal()
        {
            Dal = VisitorRecordDAL;
        }

        public bool SaveVisitorRecord(Log_VisitorRecord entity)
        {
            try
            {
                entity.CreateDate = DateTime.Now;
                return Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
