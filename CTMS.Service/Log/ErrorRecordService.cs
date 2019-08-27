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
    using CTMS.Common.Extension;
    /// <summary>
    /// 
    /// </CTMS
    public partial class ErrorRecordService:BaseService<Log_ErrorRecord>,IErrorRecordService
    {
        private readonly IErrorRecordDAL ErrorRecordDAL;
        private readonly CTMSContext CTMSContext;
        public ErrorRecordService(CTMSContext CTMSContext, IErrorRecordDAL ErrorRecordDAL)
        {
            this.CTMSContext = CTMSContext;
            this.ErrorRecordDAL = ErrorRecordDAL;
            this.Dal = ErrorRecordDAL;
        }
        public override void SetDal()
        {
            Dal = ErrorRecordDAL;
        }

        public bool SaveErrorRecord(Log_ErrorRecord entity)
        {
            try
            {
                entity.ClientID = entity.ClientID.ToInt().ToByte();
                entity.State = entity.State.ToBool();
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
