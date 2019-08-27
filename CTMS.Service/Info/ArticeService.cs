using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace CTMS.Service.Info
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IService.Info;
    using CTMS.IDAL.Info;
    using CTMS.Common.Json;
    using CTMS.Common.Security;
    using CTMS.Common.Extension;
    using CTMS.Common.Utility;
    /// <summary>
    /// 
    /// </summary>
    public partial class ArticeService:BaseService<Info_Artice>,IArticeService
    {
        private readonly IArticeDAL ArticeDAL;
        private readonly CTMSContext CTMSContext;
        public ArticeService(CTMSContext CTMSContext, IArticeDAL ArticeDAL)
        {
            this.CTMSContext = CTMSContext;
            this.ArticeDAL = ArticeDAL;
            this.Dal = ArticeDAL;
        }
        public override void SetDal()
        {
            Dal = ArticeDAL;
        }

        public bool IsExists(int systemId, string companyId, string articeId)
        {
            try
            {
                return IsExists(m => m.SystemID == systemId && m.CompanyID == companyId && m.ArticeID == articeId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool SaveArtice(Info_Artice entity)
        {
            try
            {
                int systemId = entity.SystemID;
                string companyId = entity.CompanyID;
                string articeId = PrimaryKeyHelper.MakePrimaryKey(PrimaryKeyHelper.PrimaryKeyType.InfoArtice);
                if (IsExists(systemId, companyId, articeId))
                    throw new Exception("主建ID重复！");
                entity.Hits = entity.Hits.ToInt();
                entity.Sort = entity.Sort.ToInt();
                entity.UpNum = entity.UpNum.ToInt();
                entity.DownNum = entity.DownNum.ToInt();
                entity.AllowComment = entity.AllowComment.ToBool();
                entity.IsTop = entity.IsTop.ToBool();
                entity.IsPush = entity.IsPush.ToBool();
                entity.IsVip = entity.IsVip.ToBool();
                entity.IsDraft = entity.IsDraft.ToBool();
                entity.IsDel = entity.IsDel.ToBool();
                entity.ArticeID = articeId;
                entity.CreateDate = DateTime.Now;
                return Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateArtice(Info_Artice entity)
        {
            try
            {
                int systemId = entity.SystemID;
                string companyId = entity.CompanyID;
                string articeId = entity.ArticeID;
                if (!IsExists(systemId, companyId, articeId))
                    throw new Exception("ID无效！");
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateArticeState(int systemId, string companyId, string articeId, bool state)
        {
            try
            {
                var entity = GetArtice(systemId, companyId, articeId);
                if (entity == null)
                    throw new Exception("artice id invalid！");
                entity.State = state;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateArticeDelete(int systemId, string companyId, string articeId, bool delete)
        {
            try
            {
                var entity = GetArtice(systemId, companyId, articeId);
                if (entity == null)
                    throw new Exception("artice id invalid！");
                entity.IsDel = delete;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateArticeHits(int systemId, string companyId, string articeId)
        {
            try
            {
                var entity = GetArtice(systemId, companyId, articeId);
                if (entity == null)
                    throw new Exception("ID无效！");
                int hits = entity.Hits.ToInt();
                entity.Hits = hits + 1;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateArticeUpNum(int systemId, string companyId, string articeId)
        {
            try
            {
                var entity = GetArtice(systemId, companyId, articeId);
                if (entity == null)
                    throw new Exception("ID无效！");
                int upNum = entity.UpNum.ToInt();
                entity.UpNum = upNum + 1;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateArticeDownNum(int systemId, string companyId, string articeId)
        {
            try
            {
                var entity = GetArtice(systemId, companyId, articeId);
                if (entity == null)
                    throw new Exception("ID无效！");
                int downNum = entity.DownNum.ToInt();
                entity.DownNum = downNum + 1;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteArtice(int systemId, string companyId, string articeId)
        {
            try
            {
                var entity = GetArtice(systemId, companyId, articeId);
                if (entity == null)
                    throw new Exception("artice id invalid！");
                if (!entity.IsDel.ToBool())
                    throw new Exception("资讯不在回收站不能操作删除！");
                return Delete(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Info_Artice GetArtice(int systemId, string companyId, string articeId)
        {
            try
            {
                var expression = ExtLinq.True<Info_Artice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.ArticeID == articeId);
                return Find(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Artice> GetArticeTop(int systemId, string companyId, bool delete, int count)
        {
            try
            {
                int total = Utility.ToTopTotal(count);
                var expression = ExtLinq.True<Info_Artice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.IsDel == delete);
                var scalarLambda = GetExpressionScalarLambda();
                return FindListTop(expression, scalarLambda, m => m.CreateDate, false, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Artice> GetArticeTop(int systemId, string companyId, string classId, bool delete, int count)
        {
            try
            {
                int total = Utility.ToTopTotal(count);
                var expression = ExtLinq.True<Info_Artice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.ClassID == classId && m.IsDel == delete);
                var scalarLambda = GetExpressionScalarLambda();
                return FindListTop(expression, scalarLambda, m => m.CreateDate, false, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Artice> GetArticeTop(int systemId, string companyId, string classId, string state, bool delete, int count)
        {
            try
            {
                bool verifyState = state.ToBool();
                int total = Utility.ToTopTotal(count);
                var expression = ExtLinq.True<Info_Artice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && (string.IsNullOrWhiteSpace(classId) ? true : m.ClassID == classId)
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == verifyState)
                && m.IsDel == delete);
                var scalarLambda = GetExpressionScalarLambda();
                return FindListTop(expression, scalarLambda, m => m.CreateDate, false, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Artice> GetArticePaging(int systemId, string companyId, bool delete, int pageId, int pageSize)
        {
            try
            {
                var expression = ExtLinq.True<Info_Artice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.IsDel == delete);
                var scalarLambda = GetExpressionScalarLambda();
                int pageIndex = Utility.ToPageIndex(pageId);
                int pageCount = Utility.ToPageCount(pageSize);
                return FindListPaging(expression, scalarLambda, m => m.CreateDate, false, pageIndex, pageCount).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Artice> GetArticePaging(int systemId, string companyId, string classId, bool delete, int pageId, int pageSize)
        {
            try
            {
                var expression = ExtLinq.True<Info_Artice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.ClassID == classId && m.IsDel == delete);
                var scalarLambda = GetExpressionScalarLambda();
                int pageIndex = Utility.ToPageIndex(pageId);
                int pageCount = Utility.ToPageCount(pageSize);
                return FindListPaging(expression, scalarLambda, m => m.CreateDate, false, pageIndex, pageCount).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Artice> GetArticePaging(int systemId, string companyId, string classId, string state, bool delete, int pageId, int pageSize)
        {
            try
            {
                bool verifyState = state.ToBool();
                var expression = ExtLinq.True<Info_Artice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && (string.IsNullOrWhiteSpace(classId) ? true : m.ClassID == classId)
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == verifyState)
                && m.IsDel == delete);
                var scalarLambda = GetExpressionScalarLambda();
                int pageIndex = Utility.ToPageIndex(pageId);
                int pageCount = Utility.ToPageCount(pageSize);
                return FindListPaging(expression, scalarLambda, m => m.CreateDate, false, pageIndex, pageCount).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Artice> SearchArtice(int systemId, string companyId, string keyword, int count)
        {
            try
            {
                int total = Utility.ToTopTotal(count);
                var expression = ExtLinq.True<Info_Artice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && m.State.Value == true && m.IsDel == false && m.Title.Contains(keyword));
                var scalarLambda = GetExpressionScalarLambda();
                return FindListTop(expression, scalarLambda, m => m.CreateDate, false, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Artice> SearchArtice(int systemId, string companyId, string startTime, string endTime, string classId, string state, string keyword, bool delete, int count)
        {
            try
            {
                DateTime dateStartTime = Utility.ToStartTime(startTime);
                DateTime dateEndTime = Utility.ToEndTime(endTime);
                bool blnState = state.ToBool();
                int total = Utility.ToTopTotal(count);
                //条件
                var expression = ExtLinq.True<Info_Artice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && m.CreateDate.Value.Date >= dateStartTime.Date && m.CreateDate.Value.Date <= dateEndTime.Date
                && (string.IsNullOrWhiteSpace(classId) ? true : m.ClassID == classId)
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == blnState)
                && m.IsDel == delete
                && (m.Title.Contains(keyword) || m.Account.Contains(keyword) || m.NickName.Contains(keyword)));
                //字段
                var scalarLambda = GetExpressionScalarLambda();
                //执行
                return FindListTop(expression, scalarLambda, m => m.CreateDate, false, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long CountArtice(int systemId, string companyId, bool delete)
        {
            try
            {
                var expression = ExtLinq.True<Info_Artice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.IsDel == delete);
                return Count(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long CountArtice(int systemId, string companyId, string classId, bool delete)
        {
            try
            {
                var expression = ExtLinq.True<Info_Artice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.ClassID == classId && m.IsDel == delete);
                return Count(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long CountArtice(int systemId, string companyId, string classId, string state, bool delete)
        {
            try
            {
                bool verifyState = state.ToBool();
                var expression = ExtLinq.True<Info_Artice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && (string.IsNullOrWhiteSpace(classId) ? true : m.ClassID == classId)
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == verifyState)
                && m.IsDel == delete);
                return Count(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long CountArtice(int systemId, string companyId, string keyword)
        {
            try
            {
                var expression = ExtLinq.True<Info_Artice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && m.State.Value == true && m.IsDel == false && m.Title.Contains(keyword));
                return Count(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long CountArtice(int systemId, string companyId, string startTime, string endTime, string classId, string state, string keyword, bool delete)
        {
            try
            {
                DateTime dateStartTime = Utility.ToStartTime(startTime);
                DateTime dateEndTime = Utility.ToEndTime(endTime);
                bool blnState = state.ToBool();
                //条件
                var expression = ExtLinq.True<Info_Artice>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && m.CreateDate.Value.Date >= dateStartTime.Date && m.CreateDate.Value.Date <= dateEndTime.Date
                && (string.IsNullOrWhiteSpace(classId) ? true : m.ClassID == classId)
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == blnState)
                && m.IsDel == delete
                && (m.Title.Contains(keyword) || m.Account.Contains(keyword) || m.NickName.Contains(keyword)));
                return Count(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region 私有化方法
        private Expression<Func<Info_Artice, Info_Artice>> GetExpressionScalarLambda()
        {
            try
            {
                Expression<Func<Info_Artice, Info_Artice>> scalarLambda = m => new Info_Artice
                {
                    SystemID = m.SystemID,
                    CompanyID = m.CompanyID,
                    ArticeID = m.ArticeID,
                    ClassID = m.ClassID,
                    ClassName = m.ClassName,
                    Title = m.Title,
                    TitleBrief = m.TitleBrief,
                    Author = m.Author,
                    Hits = m.Hits,
                    UpNum = m.UpNum,
                    DownNum = m.DownNum,
                    AllowComment = m.AllowComment,
                    IsTop = m.IsTop,
                    IsPush = m.IsPush,
                    State = m.State,
                    IsDel = m.IsDel,
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
