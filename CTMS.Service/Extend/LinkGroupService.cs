using System;
using System.Linq;
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
    using CTMS.Common.Extension;
    /// <summary>
    /// 
    /// </summary>
    public partial class LinkGroupService:BaseService<Extend_LinkGroup>,ILinkGroupService
    {
        private readonly ILinkGroupDAL LinkGroupDAL;
        private readonly CTMSContext CTMSContext;
        public LinkGroupService(CTMSContext CTMSContext, ILinkGroupDAL LinkGroupDAL)
        {
            this.CTMSContext = CTMSContext;
            this.LinkGroupDAL = LinkGroupDAL;
            this.Dal = LinkGroupDAL;
        }
        public override void SetDal()
        {
            Dal = LinkGroupDAL;
        }

        public bool SaveLinkGroup(Extend_LinkGroup entity)
        {
            try
            {
                var linkGroup = PrimaryKeyHelper.PrimaryKeyType.ExtendLinkGroup;
                var version = PrimaryKeyHelper.PrimaryKeyLen.V1;
                string linkGroupId = PrimaryKeyHelper.MakePrimaryKey(linkGroup, version);
                entity.GroupID = linkGroupId;
                entity.Sort = entity.Sort.ToInt();
                entity.IsExternal = entity.IsExternal.ToBool();
                entity.State = entity.State.ToBool();
                entity.CreateDate = DateTime.Now;
                return Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateLinkGroup(Extend_LinkGroup entity)
        {
            try
            {
                entity.Sort = entity.Sort.ToInt();
                entity.IsExternal = entity.IsExternal.ToBool();
                entity.State = entity.State.ToBool();
                entity.CreateDate = DateTime.Now;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateLinkGroupState(int systemId, string companyId, string groupId, bool state)
        {
            try
            {
                var expression = ExtLinq.True<Extend_LinkGroup>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.GroupID == groupId);
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
        public bool UpdateLinkGroupSort(int systemId, string companyId, string groupId, int sort)
        {
            try
            {
                var expression = ExtLinq.True<Extend_LinkGroup>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.GroupID == groupId);
                if (!IsExists(expression))
                    throw new Exception("类别ID无效！");
                var entity = Find(expression);
                entity.Sort = sort;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteLinkGroup(int systemId, string companyId, string groupId)
        {
            try
            {
                var expression = ExtLinq.True<Extend_LinkGroup>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.GroupID == groupId);
                if (!IsExists(expression))
                    throw new Exception("分组ID无效！");
                var expressionLink = ExtLinq.True<Extend_Link>();
                expressionLink = expressionLink.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.GroupID == groupId);
                var dbContext = new DAL.BaseDAL(CTMSContext);
                var isUse = dbContext.IsExists(expressionLink);
                if (isUse)
                    throw new Exception("分组ID已被使用，不能操作删除！");
                return Delete(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Extend_LinkGroup GetLinkGroup(int systemId, string companyId, string groupId)
        {
            try
            {
                var expression = ExtLinq.True<Extend_LinkGroup>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.GroupID == groupId);
                if (!IsExists(expression))
                    throw new Exception("类别ID无效！");
                return Find(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Extend_LinkGroup> GetLinkGroup(int systemId, string companyId)
        {
            try
            {
                var expression = ExtLinq.True<Extend_LinkGroup>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId);
                return FindList(expression, m => m.Sort, false).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Extend_LinkGroup> GetLinkGroupByState(int systemId, string companyId, string state)
        {
            try
            {
                bool blnState = state.ToBool();
                var expression = ExtLinq.True<Extend_LinkGroup>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == blnState));
                return FindList(expression, m => m.Sort, false).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
