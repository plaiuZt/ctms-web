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
    using CTMS.Common.Utility;
    using CTMS.Common.Json;
    using CTMS.Common.Security;
    using CTMS.Common.Extension;
    /// <summary>
    /// 
    /// </summary>
    public partial class PageService:BaseService<Info_Page>,IPageService
    {
        private readonly IPageDAL PageDAL;
        private readonly CTMSContext CTMSContext;
        public PageService(CTMSContext CTMSContext, IPageDAL PageDAL)
        {
            this.CTMSContext = CTMSContext;
            this.PageDAL = PageDAL;
            this.Dal = PageDAL;
        }
        public override void SetDal()
        {
            Dal = PageDAL;
        }

        public bool SavePage(Info_Page entity)
        {
            try
            {
                var infoPage = PrimaryKeyHelper.PrimaryKeyType.InfoPage;
                var primaryKeyLen = PrimaryKeyHelper.PrimaryKeyLen.V1;
                string pageId = PrimaryKeyHelper.MakePrimaryKey(infoPage, primaryKeyLen);
                int sort = entity.Sort.ToInt();
                entity.PageID = pageId;
                entity.Sort = sort;
                entity.CreateDate = DateTime.Now;
                return Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdatePage(Info_Page entity)
        {
            try
            {
                int systemId = entity.SystemID;
                string companyId = entity.CompanyID;
                string pageId = entity.PageID;
                int sort = entity.Sort.ToInt();
                if (!IsExists(m => m.SystemID == systemId && m.CompanyID == companyId && m.PageID == pageId))
                    throw new Exception("id invalid！");
                entity.Sort = sort;
                entity.CreateDate = DateTime.Now;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdatePageState(int systemId, string companyId, string pageId, bool state)
        {
            try
            {
                var entity = Find(m => m.SystemID == systemId && m.CompanyID == companyId && m.PageID == pageId);
                entity.State = state;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdatePageSort(int systemId, string companyId, string pageId, int sort)
        {
            try
            {
                var entity = Find(m => m.SystemID == systemId && m.CompanyID == companyId && m.PageID == pageId);
                entity.Sort = sort;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeletePage(int systemId, string companyId, string pageId)
        {
            try
            {
                var expression = ExtLinq.True<Info_Page>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.PageID == pageId);
                if (!IsExists(expression))
                    throw new Exception("delete id invalid！");
                return Delete(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Info_Page GetPage(int systemId, string companyId, string pageId)
        {
            try
            {
                var expression = ExtLinq.True<Info_Page>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.PageID == pageId);
                return Find(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Info_Page GetPageByClassId(int systemId, string companyId, string classId)
        {
            try
            {
                var expression = ExtLinq.True<Info_Page>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.ClassID == classId);
                return Find(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Page> GetPage(int systemId, string companyId, string classId, string state)
        {
            try
            {
                bool verifyState = state.ToBool();
                var expression = ExtLinq.True<Info_Page>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && (string.IsNullOrWhiteSpace(classId) ? true : m.ClassID == classId)
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == verifyState));
                var expressionScalarLambda = GetExpressionScalarLambda();
                return FindList(expression, expressionScalarLambda, m => m.CreateDate, false).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Page> GetPageTop(int systemId, string companyId, int count)
        {
            try
            {
                var expression = ExtLinq.True<Info_Page>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId);
                var expressionScalarLambda = GetExpressionScalarLambda();
                return FindListTop(expression, expressionScalarLambda, m => m.CreateDate, false, count).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Page> GetPagePaging(int systemId, string companyId, int pageId, int pageSize)
        {
            try
            {
                var expression = ExtLinq.True<Info_Page>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId);
                int pageIndex = Utility.ToPageIndex(pageId);
                int pageCount = Utility.ToPageCount(pageSize);
                var expressionScalarLambda = GetExpressionScalarLambda();
                return FindListPaging(expression, expressionScalarLambda, m => m.CreateDate, false, pageIndex, pageCount).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Page> SearchPage(int systemId, string companyId, string startTime, string endTime, string classId, string state, string keyword, int count)
        {
            try
            {
                DateTime dateStartTime = Utility.ToStartTime(startTime);
                DateTime dateEndTime = Utility.ToEndTime(endTime);
                bool blnState = state.ToBool();
                int total = Utility.ToTopTotal(count);
                //条件
                var expression = ExtLinq.True<Info_Page>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && m.CreateDate.Value.Date >= dateStartTime.Date && m.CreateDate.Value.Date <= dateEndTime.Date
                && (string.IsNullOrWhiteSpace(classId) ? true : m.ClassID == classId)
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == blnState)
                && m.Title.Contains(keyword));
                //执行
                var expressionScalarLambda = GetExpressionScalarLambda();
                return FindListTop(expression, expressionScalarLambda, m => m.CreateDate, false, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long CountPage(int systemId, string companyId)
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

        #region 私有化方法
        private Expression<Func<Info_Page, Info_Page>> GetExpressionScalarLambda()
        {
            try
            {
                Expression<Func<Info_Page, Info_Page>> scalarLambda = m => new Info_Page
                {
                    SystemID = m.SystemID,
                    CompanyID = m.CompanyID,
                    PageID=m.PageID,
                    Title = m.Title,
                    ClassID = m.ClassID,
                    ClassName = m.ClassName,
                    ImgSrc = m.ImgSrc,
                    ImgArray = m.ImgArray,
                    Sort=m.Sort,
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
