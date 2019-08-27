using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Service.Info
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IService.Info;
    using CTMS.IDAL.Info;
    using CTMS.Common.Json;
    using CTMS.Common.Extension;
    using CTMS.Common.Security;

    public partial class NoticeCategoryService:BaseService<Info_NoticeCategory>,INoticeCategoryService
    {
        private readonly INoticeCategoryDAL NoticeCategoryDAL;
        private readonly CTMSContext CTMSContext;
        public NoticeCategoryService(CTMSContext CTMSContext, INoticeCategoryDAL NoticeCategoryDAL)
        {
            this.CTMSContext = CTMSContext;
            this.NoticeCategoryDAL = NoticeCategoryDAL;
            this.Dal = NoticeCategoryDAL;
        }
        public override void SetDal()
        {
            Dal = NoticeCategoryDAL;
        }

        public bool SaveNoticeCategory(Info_NoticeCategory entity)
        {
            try
            {
                var infoNoticeCategory = PrimaryKeyHelper.PrimaryKeyType.InfoNoticeCategory;
                var version = PrimaryKeyHelper.PrimaryKeyLen.V1;
                int systemId = entity.SystemID;
                string companyId = entity.CompanyID;
                string categoryId = PrimaryKeyHelper.MakePrimaryKey(infoNoticeCategory, version);
                string categoryName = entity.CategoryName;
                if (IsExists(m => m.SystemID == systemId && m.CompanyID == companyId && m.CategoryID == categoryId))
                    throw new Exception("主建ID重复！");
                if (IsExists(m => m.SystemID == systemId && m.CompanyID == companyId && m.CategoryName == categoryName))
                    throw new Exception("类别名称已存在！");
                entity.CategoryID = categoryId;
                entity.CreateDate = DateTime.Now;
                return Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateNoticeCategory(Info_NoticeCategory entity)
        {
            try
            {
                int systemId = entity.SystemID;
                string companyId = entity.CompanyID;
                string categoryId = entity.CategoryID;
                string categoryName = entity.CategoryName;
                if (!IsExists(m => m.SystemID == systemId && m.CompanyID == companyId && m.CategoryID == categoryId))
                    throw new Exception("类别ID无效！");
                if (IsExists(m => m.SystemID == systemId && m.CompanyID == companyId && m.CategoryID != categoryId&&m.CategoryName==categoryName))
                    throw new Exception("类别名称已存在！");
                entity.CreateDate = DateTime.Now;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateNoticeCategoryState(int systemId, string companyId, string categoryId, bool state)
        {
            try
            {
                var expression = ExtLinq.True<Info_NoticeCategory>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.CategoryID == categoryId);
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
        public bool DeleteNoticeCategory(int systemId, string companyId, string categoryId)
        {
            try
            {
                var expression = ExtLinq.True<Info_NoticeCategory>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.CategoryID == categoryId);
                if (!IsExists(expression))
                    throw new Exception("类别ID无效！");
                var expressionNotice = ExtLinq.True<Info_Notice>();
                expressionNotice = expressionNotice.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.ClassID == categoryId);
                var dbContext = new DAL.BaseDAL(CTMSContext);
                var isUse = dbContext.IsExists(expressionNotice);
                if (isUse)
                    throw new Exception("类别ID已被使用，不能操作删除！");
                return Delete(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Info_NoticeCategory GetNoticeCategory(int systemId, string companyId, string categoryId)
        {
            try
            {
                var expression = ExtLinq.True<Info_NoticeCategory>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.CategoryID == categoryId);
                if (!IsExists(expression))
                    throw new Exception("类别ID无效！");
                return Find(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_NoticeCategory> GetNoticeCategory(int systemId, string companyId)
        {
            try
            {
                var expression = ExtLinq.True<Info_NoticeCategory>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId);
                return FindList(expression, m => m.Sort, false).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_NoticeCategory> GetNoticeCategoryByState(int systemId, string companyId, string state)
        {
            try
            {
                bool blnState = state.ToBool();
                var expression = ExtLinq.True<Info_NoticeCategory>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == blnState));
                return FindList(expression, m => m.Sort, false).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
