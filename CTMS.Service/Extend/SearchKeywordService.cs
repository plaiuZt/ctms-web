using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Service.Extend
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IService.Extend;
    using CTMS.IDAL.Extend;
    using CTMS.Common.Json;
    using CTMS.Common.Security;
    using CTMS.Model.Extend;
    using CTMS.Common.Utility;
    using CTMS.IService;
    using CTMS.Common.Extension;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    public partial class SearchKeywordService:BaseService<Extend_SearchKeyword>,ISearchKeywordService
    {
        private readonly ISearchKeywordDAL SearchKeywordDAL;
        private readonly CTMSContext CTMSContext;
        public SearchKeywordService(CTMSContext CTMSContext, ISearchKeywordDAL SearchKeywordDAL)
        {
            this.CTMSContext = CTMSContext;
            this.SearchKeywordDAL = SearchKeywordDAL;
            this.Dal = SearchKeywordDAL;
        }
        public override void SetDal()
        {
            Dal = SearchKeywordDAL;
        }

        public bool SaveSearchKeyword(Extend_SearchKeyword entity)
        {
            try
            {
                entity.Hits = entity.Hits.ToInt();
                entity.IsTop = entity.IsTop.ToBool();
                entity.State = entity.State.ToBool();
                entity.CreateDate = DateTime.Now;
                return Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateSearchKeywordState(long id, bool state)
        {
            try
            {
                var entity = Find(m => m.ID == id);
                if (entity == null)
                    throw new Exception("id invalid！");
                entity.State = state;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateSearchKeywordTop(long id, bool top)
        {
            try
            {
                var entity = Find(m => m.ID == id);
                if (entity == null)
                    throw new Exception("id invalid！");
                entity.IsTop = top;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteSearchKeyword(long id)
        {
            try
            {
                var entity = Find(m => m.ID == id);
                return Delete(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Extend_SearchKeyword GetSearchKeyword(long id)
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
        public List<Extend_SearchKeyword> GetSearchKeyword(int systemId, string companyId, int count)
        {
            try
            {
                var expression = ExtLinq.True<Extend_SearchKeyword>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId);

                var dbContext = new DAL.BaseDAL(CTMSContext);
                var db = dbContext.DbEntities();
                return db.Extend_SearchKeyword.Where(expression)
                    .OrderByDescending(m => m.IsTop)
                    .OrderByDescending(m => m.ID)
                    //.ThenByDescending(m => m.ID)
                    .Take(count)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Extend_SearchKeyword> GetSearchKeywordByKeyword(int systemId, string companyId,string keyword, int count)
        {
            try
            {
                int total = Utility.ToTopTotal(count);
                var expression = ExtLinq.True<Extend_SearchKeyword>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.Keyword == keyword);
                return FindListTop(expression, m => m.ID, false, total).ToList<Extend_SearchKeyword>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Extend_SearchKeyword> GetSearchKeywordByTop(int systemId, string companyId, string memberId, int count)
        {
            try
            {
                int total = Utility.ToTopTotal(count);
                var expression = ExtLinq.True<Extend_SearchKeyword>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && m.IsTop == true
                && (string.IsNullOrWhiteSpace(memberId) ? m.MemberID.Equals(m.MemberID) : m.MemberID == memberId)
                );
                return FindListTop(expression, m => m.ID, false, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Extend_SearchKeyword> SearchSearchKeyword(int systemId, string companyId, string startTime, string endTime, string keyword, int count)
        {
            try
            {
                DateTime dateStartTime = Utility.ToStartTime(startTime);
                DateTime dateEndTime = Utility.ToEndTime(endTime);
                int total = Utility.ToTopTotal(count);
                //条件
                var expression = ExtLinq.True<Extend_SearchKeyword>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && m.CreateDate.Value.Date >= dateStartTime.Date && m.CreateDate.Value.Date <= dateEndTime.Date
                && (m.Keyword.Contains(keyword)));
                //执行
                return FindListTop(expression, m => m.ID, false, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<CountSearchKeywordByKeywordResult> CountSearchKeywordByKeyword(int systemId, string companyId, int count)
        {
            try
            {
                int total = Utility.ToTopTotal(count);
                var expression = ExtLinq.True<Extend_SearchKeyword>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId);
                var dbContext = new DAL.BaseDAL(CTMSContext);
                var db = dbContext.DbEntities();
                var lists = db.Extend_SearchKeyword
                    .Where(expression)
                    .ToList()
                    .GroupBy(x => x.Keyword).Select(m => new
                    {
                        ID = m.Max(x => x.ID),
                        Keyword = m.Key,
                        Total = m.Count(),
                        MinDate = m.Min(x => x.CreateDate),
                        MaxDate = m.Max(x => x.CreateDate)
                    }).Take(count).ToList();
                return lists.ToJson().ToObject<List<CountSearchKeywordByKeywordResult>>();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<CountSearchKeywordByKeywordResult> CountSearchKeywordByKeyword(int systemId, string companyId, string startTime, string endTime, string keyword, int count)
        {
            try
            {
                DateTime dateStartTime = Utility.ToStartTime(startTime);
                DateTime dateEndTime = Utility.ToEndTime(endTime);
                int total = Utility.ToTopTotal(count);
                //条件
                var expression = ExtLinq.True<Extend_SearchKeyword>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && m.CreateDate.Value.Date >= dateStartTime.Date && m.CreateDate.Value.Date <= dateEndTime.Date
                && (m.Keyword.Contains(keyword)));
                //执行
                var dbContext = new DAL.BaseDAL(CTMSContext);
                var db = dbContext.DbEntities();
                var lists = db.Extend_SearchKeyword
                    .Where(expression)
                    .ToList()
                    .GroupBy(m => m.Keyword).Select(m => new
                    {
                        ID = m.Max(x => x.ID),
                        Keyword = m.Key,
                        Total = m.Count(),
                        MinDate = m.Min(x => x.CreateDate),
                        MaxDate = m.Max(x => x.CreateDate)
                    }).Take(count).ToList();
                return lists.ToJson().ToObject<List<CountSearchKeywordByKeywordResult>>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long CountSearchKeyword(int systemId, string companyId)
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
