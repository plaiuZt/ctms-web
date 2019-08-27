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
    using CTMS.Common.Utility;

    /// <summary>
    /// 
    /// </summary>
    public partial class LinkService:BaseService<Extend_Link>,ILinkService
    {
        private readonly ILinkDAL LinkDAL;
        private readonly CTMSContext CTMSContext;
        public LinkService(CTMSContext CTMSContext, ILinkDAL LinkDAL)
        {
            this.CTMSContext = CTMSContext;
            this.LinkDAL = LinkDAL;
            this.Dal = LinkDAL;
        }
        public override void SetDal()
        {
            Dal = LinkDAL;
        }

        public bool SaveLink(Extend_Link entity)
        {
            try
            {
                var link = PrimaryKeyHelper.PrimaryKeyType.ExtendLink;
                var version = PrimaryKeyHelper.PrimaryKeyLen.V1;
                string linkId = PrimaryKeyHelper.MakePrimaryKey(link, version);
                string logo = entity.Logo;
                int typeId = string.IsNullOrEmpty(logo) ? 1 : 2;
                string typeName = string.IsNullOrEmpty(logo) ? "文字" : "LOGO";

                entity.LinkID = linkId;
                entity.TypeID = typeId.ToByte();
                entity.TypeName = typeName;
                entity.Sort = entity.Sort.ToInt();
                entity.State = entity.State.ToBool();
                entity.CreateDate = DateTime.Now;
                return Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateLink(Extend_Link entity)
        {
            try
            {
                string logo = entity.Logo;
                int typeId = string.IsNullOrEmpty(logo) ? 1 : 2;
                string typeName = string.IsNullOrEmpty(logo) ? "文字" : "LOGO";

                entity.TypeID = typeId.ToByte();
                entity.TypeName = typeName;
                entity.Sort = entity.Sort.ToInt();
                entity.State = entity.State.ToBool();
                entity.CreateDate = DateTime.Now;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateLinkState(int systemId, string companyId, string linkId, bool state)
        {
            try
            {
                var expression = ExtLinq.True<Extend_Link>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.LinkID == linkId);
                var entity = Find(expression);
                if (entity==null)
                    throw new Exception("主建ID无效！");
                entity.State = state;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateLinkSort(int systemId, string companyId, string linkId, int sort)
        {
            try
            {
                var expression = ExtLinq.True<Extend_Link>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.LinkID == linkId);
                var entity = Find(expression);
                if (entity == null)
                    throw new Exception("主建ID无效！");
                entity.Sort = Math.Abs(sort);
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteLink(int systemId, string companyId, string linkId)
        {
            try
            {
                var expression = ExtLinq.True<Extend_Link>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.LinkID == linkId);
                return Delete(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Extend_Link GetLink(int systemId, string companyId, string linkId)
        {
            try
            {
                var expression = ExtLinq.True<Extend_Link>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.LinkID == linkId);
                return Find(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Extend_Link> GetLinkTop(int systemId, string companyId, int count)
        {
            try
            {
                var expression = ExtLinq.True<Extend_Link>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId);
                int total = Utility.ToTopTotal(count);
                return FindListTop(expression, m => m.Sort, true, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Extend_Link> GetLinkTop(int systemId, string companyId, string typeId, string state, int count)
        {
            try
            {
                byte byteTypeId = typeId.ToByte();
                bool blnState = state.ToBool();
                var expression = ExtLinq.True<Extend_Link>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && m.TypeID.Equals(string.IsNullOrWhiteSpace(typeId) ? m.TypeID : byteTypeId)
                && m.State.Equals(string.IsNullOrWhiteSpace(typeId) ? m.State : blnState));
                int total = Utility.ToTopTotal(count);
                return FindListTop(expression, m => m.Sort, true, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Extend_Link> GetLinkTop(int systemId, string companyId, string groupId, string typeId, string state, int count)
        {
            try
            {
                byte byteTypeId = typeId.ToByte();
                bool blnState = state.ToBool();
                var expression = ExtLinq.True<Extend_Link>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && (string.IsNullOrWhiteSpace(groupId) ? true : m.GroupID == groupId)
                && (string.IsNullOrWhiteSpace(typeId) ? true : m.TypeID.Value == byteTypeId)
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == blnState));
                int total = Utility.ToTopTotal(count);
                return FindListTop(expression, m => m.Sort, true, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Extend_Link> GetLinkPaging(int systemId, string companyId, int pageId, int pageSize)
        {
            try
            {
                var expression = ExtLinq.True<Extend_Link>();
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
        public List<Extend_Link> GetLinkPaging(int systemId, string companyId, string groupId, string typeId, string state, int pageId, int pageSize)
        {
            try
            {
                byte byteTypeId = typeId.ToByte();
                bool blnState = state.ToBool();
                var expression = ExtLinq.True<Extend_Link>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && (string.IsNullOrWhiteSpace(groupId) ? true : m.GroupID == groupId)
                && (string.IsNullOrWhiteSpace(typeId) ? true : m.TypeID.Value == byteTypeId)
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == blnState));
                int pageIndex = Utility.ToPageIndex(pageId);
                int pageCount = Utility.ToPageCount(pageSize);
                return FindListPaging(expression, m => m.CreateDate, false, pageIndex, pageCount).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Extend_Link> SearchLink(int systemId, string companyId, string startTime, string endTime, string state, string keyword, int count)
        {
            try
            {
                DateTime dateStartTime = Utility.ToStartTime(startTime);
                DateTime dateEndTime = Utility.ToEndTime(endTime);
                bool blnState = state.ToBool();
                int total = Utility.ToTopTotal(count);
                //条件
                var expression = ExtLinq.True<Extend_Link>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && m.CreateDate.Value.Date >= dateStartTime.Date && m.CreateDate.Value.Date <= dateEndTime.Date
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == blnState)
                && (m.Name.Contains(keyword) || m.Url.Contains(keyword)) );
                //执行
                return FindListTop(expression, m => m.CreateDate, false, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long CountLink(int systemId, string companyId)
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
        public long CountLink(int systemId, string companyId, string groupId, string typeId, string state)
        {
            try
            {
                byte byteTypeId = typeId.ToByte();
                bool blnState = state.ToBool();
                var expression = ExtLinq.True<Extend_Link>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && (string.IsNullOrWhiteSpace(groupId) ? true : m.GroupID == groupId)
                && (string.IsNullOrWhiteSpace(typeId) ? true : m.TypeID.Value == byteTypeId)
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == blnState));
                return Count(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long CountLink(int systemId, string companyId, string startTime, string endTime, string state, string keyword)
        {
            try
            {
                DateTime dateStartTime = Utility.ToStartTime(startTime);
                DateTime dateEndTime = Utility.ToEndTime(endTime);
                bool blnState = state.ToBool();
                var expression = ExtLinq.True<Extend_Link>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && m.CreateDate.Value.Date >= dateStartTime.Date && m.CreateDate.Value.Date <= dateEndTime.Date
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == blnState)
                && (m.Name.Contains(keyword) || m.Url.Contains(keyword)));
                return Count(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
