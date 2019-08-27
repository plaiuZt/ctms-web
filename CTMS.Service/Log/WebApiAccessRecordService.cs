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
    public partial class WebApiAccessRecordService:BaseService<Log_WebApiAccessRecord>,IWebApiAccessRecordService
    {
        private readonly IWebApiAccessRecordDAL SysWebApiAccessRecordDAL;
        private readonly CTMSContext CTMSContext;
        public WebApiAccessRecordService(CTMSContext CTMSContext, IWebApiAccessRecordDAL SysWebApiAccessRecordDAL)
        {
            this.CTMSContext = CTMSContext;
            this.SysWebApiAccessRecordDAL = SysWebApiAccessRecordDAL;
            this.Dal = SysWebApiAccessRecordDAL;
        }
        public override void SetDal()
        {
            Dal = SysWebApiAccessRecordDAL;
        }

        public bool IsExists(long id)
        {
            try
            {
                return IsExists(m => m.ID == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool SaveSysWebApiAccessRecord(Log_WebApiAccessRecord entity)
        {
            try
            {
                entity.State = false;
                entity.CreateDate = DateTime.Now;
                entity.UpdateDate = null;
                return Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateSysWebApiAccessRecordState(long id, string result, bool state)
        {
            try
            {
                var entity = GetSysWebApiAccessRecord(id);
                entity.Result = result;
                entity.State = state;
                entity.UpdateDate = DateTime.Now;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Log_WebApiAccessRecord GetSysWebApiAccessRecord(long id)
        {
            try
            {
                if (!IsExists(id))
                    throw new Exception("id invalid！");
                return Find(m => m.ID == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
