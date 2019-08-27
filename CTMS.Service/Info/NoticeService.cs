using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace CTMS.Service.Info
{    
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.IService.Info;
    using CTMS.IDAL.Info;
    using CTMS.Common.Json;
    using CTMS.Common.Extension;
    using CTMS.Common.Security;
    using CTMS.Common.Utility;
    /// <summary>
    /// 
    /// </summary>
    public partial class NoticeService:BaseService<Info_Notice>,INoticeService
    {
        private readonly INoticeDAL NoticeDAL;
        private readonly CTMSContext CTMSContext;
        public NoticeService(CTMSContext CTMSContext, INoticeDAL NoticeDAL)
        {
            this.CTMSContext = CTMSContext;
            this.NoticeDAL = NoticeDAL;
            this.Dal = NoticeDAL;
        }
        public override void SetDal()
        {
            Dal = NoticeDAL;
        }

        public bool IsExists(int systemId, string companyId, string noticeId)
        {
            try
            {
                return IsExists(m => m.SystemID == systemId && m.CompanyID == companyId && m.NoticeID == noticeId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool SaveNotice(Info_Notice entity)
        {
            try
            {
                int systemId = entity.SystemID;
                string companyId = entity.CompanyID;
                string noticeId = PrimaryKeyHelper.MakePrimaryKey(PrimaryKeyHelper.PrimaryKeyType.InfoNotice);
                if (IsExists(systemId, companyId, noticeId))
                    throw new Exception("主建ID重复！");
                entity.NoticeID = noticeId;
                entity.CreateDate = DateTime.Now;
                return Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateNotice(Info_Notice entity)
        {
            try
            {
                int systemId = entity.SystemID;
                string companyId = entity.CompanyID;
                string noticeId = entity.NoticeID;
                if (!IsExists(systemId, companyId, noticeId))
                    throw new Exception("主建ID无效！");
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateNoticeState(int systemId, string companyId, string noticeId, bool state)
        {
            try
            {
                var expression = ExtLinq.True<Info_Notice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.NoticeID == noticeId);
                if (!IsExists(expression))
                    throw new Exception("类别ID无效！");
                var entity = Find(expression);
                entity.State = state;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteNotice(int systemId, string companyId, string noticeId)
        {
            try
            {
                var expression = ExtLinq.True<Info_Notice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.NoticeID == noticeId);
                if (!IsExists(expression))
                    throw new Exception("主建ID无效！");
                return Delete(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Info_Notice GetNotice(int systemId, string companyId, string noticeId)
        {
            try
            {
                var expression = ExtLinq.True<Info_Notice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.NoticeID == noticeId);
                if (!IsExists(expression))
                    throw new Exception("主建ID无效！");
                return Find(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Notice> GetNoticeTop(int systemId, string companyId, int count)
        {
            try
            {
                int total = Utility.ToTopTotal(count);
                var expression = ExtLinq.True<Info_Notice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId);
                var expressionScalarLambda = GetExpressionScalarLambda();
                return FindListTop(expression, expressionScalarLambda, m => m.CreateDate, false, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Notice> GetNoticeTop(int systemId, string companyId, string state, int count)
        {
            try
            {
                bool noticeState = state.ToBool();
                int total = Utility.ToTopTotal(count);
                var expression = ExtLinq.True<Info_Notice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == noticeState));
                var expressionScalarLambda = GetExpressionScalarLambda();
                return FindListTop(expression, expressionScalarLambda, m => m.CreateDate, false, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Notice> GetNoticeTop(int systemId, string companyId, string classId, string state, int count)
        {
            try
            {
                bool noticeState = state.ToBool();
                int total = Utility.ToTopTotal(count);
                var expression = ExtLinq.True<Info_Notice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId 
                && (string.IsNullOrWhiteSpace(classId) ? true : m.ClassID == classId)
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == noticeState)
                );
                var expressionScalarLambda = GetExpressionScalarLambda();
                return FindListTop(expression, expressionScalarLambda, m => m.CreateDate, false, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Notice> GetNoticePaging(int systemId, string companyId, int pageId, int pageSize)
        {
            try
            {
                var expression = ExtLinq.True<Info_Notice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId);
                var expressionScalarLambda = GetExpressionScalarLambda();
                int pageIndex = Utility.ToPageIndex(pageId);
                int pageCount = Utility.ToPageCount(pageSize);
                return FindListPaging(expression, expressionScalarLambda, m => m.CreateDate, false, pageIndex, pageCount).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Notice> GetNoticePaging(int systemId, string companyId, string state, int pageId, int pageSize)
        {
            try
            {
                bool noticeState = state.ToBool();
                var expression = ExtLinq.True<Info_Notice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && (string.IsNullOrWhiteSpace(state) ? m.State.Value.Equals(m.State) : m.State.Value == noticeState));
                var expressionScalarLambda = GetExpressionScalarLambda();
                int pageIndex = Utility.ToPageIndex(pageId);
                int pageCount = Utility.ToPageCount(pageSize);
                return FindListPaging(expression, expressionScalarLambda, m => m.CreateDate, false, pageIndex, pageCount).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Notice> GetNoticePaging(int systemId, string companyId, string classId, string state, int pageId, int pageSize)
        {
            try
            {
                bool noticeState = state.ToBool();
                var expression = ExtLinq.True<Info_Notice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && (string.IsNullOrWhiteSpace(classId) ? true : m.ClassID == classId)
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == noticeState));
                var expressionScalarLambda = GetExpressionScalarLambda();
                int pageIndex = Utility.ToPageIndex(pageId);
                int pageCount = Utility.ToPageCount(pageSize);
                return FindListPaging(expression, expressionScalarLambda, m => m.CreateDate, false, pageIndex, pageCount).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Notice> SearchNotice(int systemId, string companyId, string startTime, string endTime, string classId, string state, string keyword, int count)
        {
            try
            {
                DateTime dateStartTime = Utility.ToStartTime(startTime);
                DateTime dateEndTime = Utility.ToEndTime(endTime);
                bool blnState = state.ToBool();
                int total = Utility.ToTopTotal(count);
                //条件
                var expression = ExtLinq.True<Info_Notice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && m.CreateDate.Value.Date >= dateStartTime.Date && m.CreateDate.Value.Date <= dateEndTime.Date
                && (string.IsNullOrWhiteSpace(classId) ? true : m.ClassID == classId)
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == blnState)
                && (m.Title.Contains(keyword) || m.StaffId.Contains(keyword) || m.StaffName.Contains(keyword)));
                //字段
                var expressionScalarLambda = GetExpressionScalarLambda();
                //执行
                return FindListTop(expression, expressionScalarLambda, m => m.CreateDate, false, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long CountNotice(int systemId, string companyId)
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
        public long CountNotice(int systemId, string companyId, string classId, string state)
        {
            try
            {
                bool blnState = state.ToBool();
                var expression = ExtLinq.True<Info_Notice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && (string.IsNullOrWhiteSpace(classId) ? m.ClassID.Contains(m.ClassID) : m.ClassID == classId)
                && (string.IsNullOrWhiteSpace(state) ? m.State.Value.Equals(m.State) : m.State.Value == blnState));
                return Count(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long CountNotice(int systemId, string companyId, string startTime, string endTime, string classId, string state, string keyword)
        {
            try
            {
                DateTime dateStartTime = Utility.ToStartTime(startTime);
                DateTime dateEndTime = Utility.ToEndTime(endTime);
                bool blnState = state.ToBool();
                var expression = ExtLinq.True<Info_Notice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && m.CreateDate.Value.Date >= dateStartTime.Date && m.CreateDate.Value.Date <= dateEndTime.Date
                && (string.IsNullOrWhiteSpace(classId) ? true : m.ClassID == classId)
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == blnState)
                && (m.Title.Contains(keyword) || m.StaffId.Contains(keyword) || m.StaffName.Contains(keyword)));
                return Count(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region 私有化方法
        private Expression<Func<Info_Notice, Info_Notice>> GetExpressionScalarLambda()
        {
            try
            {
                Expression<Func<Info_Notice, Info_Notice>> scalarLambda = m => new Info_Notice
                {
                    SystemID = m.SystemID,
                    CompanyID = m.CompanyID,
                    NoticeID = m.NoticeID,
                    Title = m.Title,
                    ClassID = m.ClassID,
                    ClassName = m.ClassName,
                    Author = m.Author,
                    ImgSrc = m.ImgSrc,
                    ImgArray=m.ImgArray,
                    StaffId = m.StaffId,
                    StaffName = m.StaffName,
                    State = m.State,
                    CreateDate = m.CreateDate
                };
                return scalarLambda;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
