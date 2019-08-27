using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Service.Service
{
    using CTMS.DbModels;
    using CTMS.DbContexts;
    using CTMS.DbStoredProcedure;
    using CTMS.IService.Service;
    using CTMS.IDAL.Service;
    using CTMS.Common.Json;
    using CTMS.Common.Security;
    using CTMS.Common.Extension;
    using CTMS.Common.Utility;
    /// <summary>
    /// 
    /// </summary>
    public partial class MessageBoardService:BaseService<Service_MessageBoard>,IMessageBoardService
    {
        private readonly IMessageBoardDAL MessageBoardDAL;
        private readonly CTMSContext CTMSContext;
        public MessageBoardService(CTMSContext CTMSContext, IMessageBoardDAL MessageBoardDAL)
        {
            this.CTMSContext = CTMSContext;
            this.MessageBoardDAL = MessageBoardDAL;
            this.Dal = MessageBoardDAL;
        }
        public override void SetDal()
        {
            Dal = MessageBoardDAL;
        }

        public bool SaveMessageBoard(Service_MessageBoard entity)
        {
            try
            {
                string messageId = PrimaryKeyHelper.MakePrimaryKey(PrimaryKeyHelper.PrimaryKeyType.ServiceMessageBoard);
                entity.MessageID = messageId;
                entity.IsTop = false;
                entity.State = false;
                entity.CreateDate = DateTime.Now;
                return Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteMessageBoard(int systemId, string companyId, string messageId)
        {
            try
            {
                return Delete(m => m.SystemID == systemId && m.CompanyID == companyId && m.MessageID == messageId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateMessageBoardState(int systemId, string companyId, string messageId, bool state)
        {
            try
            {
                var entity = GetMessageBoard(systemId, companyId, messageId);
                if (entity == null)
                    throw new Exception("not data！");
                entity.State = state;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateMessageBoardReply(int systemId, string companyId, string messageId, string reply, string replyStaffId, string replyStaffName, bool state)
        {
            try
            {
                var entity = GetMessageBoard(systemId, companyId, messageId);
                if (entity == null)
                    throw new Exception("not data！");
                entity.Reply = reply;
                entity.ReplyStaffId = replyStaffId;
                entity.ReplyStaffName = replyStaffName;
                entity.ReplyTime = DateTime.Now;
                entity.State = state;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Service_MessageBoard GetMessageBoard(int systemId, string companyId, string messageId)
        {
            try
            {
                return Find(m => m.SystemID == systemId && m.CompanyID == companyId && m.MessageID == messageId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Service_MessageBoard> GetMessageBoardTop(int systemId, string companyId, int count)
        {
            try
            {
                var expression = ExtLinq.True<Service_MessageBoard>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId);
                return FindListTop(expression, m => m.CreateDate, false, count).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Service_MessageBoard> GetMessageBoardPaging(int systemId, string companyId, int pageId, int pageSize)
        {
            try
            {
                var expression = ExtLinq.True<Service_MessageBoard>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId);
                int pageIndex = Utility.ToPageIndex(pageId);
                int pageCount = Utility.ToPageCount(pageSize);
                return FindListPaging(expression, m => m.CreateDate, false, pageIndex, pageCount).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Service_MessageBoard> GetMessageBoardPaging(int systemId, string companyId, string state, int pageId, int pageSize)
        {
            try
            {
                bool blnState = state.ToBool();
                var expression = ExtLinq.True<Service_MessageBoard>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == blnState));
                return FindListPaging(expression, m => m.CreateDate, false, pageId, pageSize).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Service_MessageBoard> SearchMessageBoard(int systemId, string companyId, string startTime, string endTime, string state, string keyword, int count)
        {
            try
            {
                DateTime dateStartTime = Utility.ToStartTime(startTime); 
                DateTime dateEndTime = Utility.ToEndTime(endTime);
                bool blnState = state.ToBool();
                int total = Utility.ToTopTotal(count);
                var expression = ExtLinq.True<Service_MessageBoard>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && m.CreateDate.Value.Date >= dateStartTime.Date && m.CreateDate.Value.Date <= dateEndTime.Date
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == blnState)
                && (m.Name.Contains(keyword) || m.Content.Contains(keyword)));
                return FindListTop(expression, m => m.CreateDate, false, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long CountMessageBoard(int systemId, string companyId)
        {
            try
            {
                var expression = ExtLinq.True<Service_MessageBoard>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId);
                return Count(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long CountMessageBoard(int systemId, string companyId, string state)
        {
            try
            {
                bool blnState = state.ToBool();
                var expression = ExtLinq.True<Service_MessageBoard>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == blnState));
                return Count(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
