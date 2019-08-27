using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Service.Log
{
    using CTMS.DbContexts;
    using CTMS.DbStoredProcedure;
    using CTMS.DbModels;
    using CTMS.IService.Log;
    using CTMS.IDAL.Log;
    using CTMS.Common.Json;
    using CTMS.Common.Extension;
    using CTMS.Common.Utility;
    /// <summary>
    /// 
    /// </summary>
    public partial class LoginRecordService:BaseService<Log_LoginRecord>,ILoginRecordService
    {
        private readonly ILoginRecordDAL LoginRecordDAL;
        private readonly CTMSContext CTMSContext;
        public LoginRecordService(CTMSContext CTMSContext, ILoginRecordDAL LoginRecordDAL)
        {
            this.CTMSContext = CTMSContext;
            this.LoginRecordDAL = LoginRecordDAL;
            this.Dal = LoginRecordDAL;
        }
        public override void SetDal()
        {
            Dal = LoginRecordDAL;
        }

        public bool SaveLoginRecord(Log_LoginRecord entity)
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
        public bool DeleteLoginRecord(int systemId, string companyId, long id)
        {
            try
            {
                return Delete(m => m.ID == id && m.SystemID == systemId && m.CompanyID == companyId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteLoginRecordAll(int systemId, string companyId)
        {
            try
            {
                DateTime time = DateTime.Now.AddDays(-3);
                var expression = ExtLinq.True<Log_LoginRecord>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.CreateDate.Value.Date <= time.Date);
                return Delete(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Log_LoginRecord GetLoginRecord(long id)
        {
            try
            {
                return Find(m => m.ID == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Log_LoginRecord GetLoginRecord(int systemId,string companyId, long id)
        {
            try
            {
                return Find(m => m.SystemID == systemId && m.CompanyID == companyId && m.ID == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Log_LoginRecord> GetLoginRecordTop(int systemId, string companyId, int count)
        {
            try
            {
                int total = Utility.ToTopTotal(count);
                var expression = ExtLinq.True<Log_LoginRecord>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId);
                return FindListTop(expression, m => m.ID, false, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Log_LoginRecord> GetLoginRecordPaging(int systemId, string companyId, int pageId, int pageSize)
        {
            try
            {
                
                var expression = ExtLinq.True<Log_LoginRecord>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId);
                int pageIndex = Utility.ToPageIndex(pageId);
                int pageCount = Utility.ToPageCount(pageSize);
                return FindListPaging(expression, m => m.ID, false, pageIndex, pageCount).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Log_LoginRecord> SearchLoginRecord(int systemId, string companyId, string startTime, string endTime, string clientId, string keyword, int count)
        {
            try
            {
                DateTime dateStartTime = Utility.ToStartTime(startTime);
                DateTime dateEndTime = Utility.ToEndTime(endTime);
                byte btClientId = clientId.ToByte();
                int total = Utility.ToTopTotal(count);
                var expression = ExtLinq.True<Log_LoginRecord>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && m.CreateDate.Value.Date >= dateStartTime.Date && m.CreateDate.Value.Date <= dateEndTime.Date
                && (string.IsNullOrWhiteSpace(clientId) ? true : m.ClientID.Value == btClientId)
                && (m.Account.Contains(keyword) || m.NickName.Contains(keyword) || m.IpAddress.Contains(keyword)));
                return FindListTop(expression, m => m.ID, false, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long CountLoginRecord(int systemId, string companyId)
        {
            try
            {
                return Count(m => m.SystemID == systemId && m.CompanyID == companyId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
