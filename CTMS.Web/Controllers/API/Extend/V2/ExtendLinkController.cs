using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTMS.Web.Controllers.API.Extend.V2
{
    using CTMS.Common.Extension;
    using CTMS.Common.Utility;
    using CTMS.IService.Extend;
    using CTMS.Web.Services;

    [ApiVersion("2.0")]
    [EnableCors("AllowSameDomain")]
    [ControllerName("extend/link")]
    public class ExtendLinkController : BaseApiController
    {
        private readonly IBaseApiManager BaseApiManager;
        private readonly IHttpContextAccessor Accessor;
        private readonly ILinkGroupService LinkGroupService;
        private readonly ILinkService LinkService;

        public ExtendLinkController(IBaseApiManager BaseApiManager, IHttpContextAccessor Accessor, ILinkGroupService LinkGroupService, ILinkService LinkService) : base(BaseApiManager)
        {
            this.BaseApiManager = BaseApiManager;
            this.Accessor = Accessor;
            this.LinkGroupService = LinkGroupService;
            this.LinkService = LinkService;
        }

        public IActionResult Index(string uuid)
        {
            long logId = 0;
            try
            {
                logId = BaseApiManager.SaveLogs(uuid);
                if (!IsUuid(uuid)) { return Error(logId, "verify uuid fail！"); }
                return Success(logId, "ok", uuid);
            }
            catch (Exception ex)
            {
                return Error(logId, ex.Message);
            }
        }
        [HttpGet("all")]
        [ActionName("group")]
        public IActionResult GetLinkGroupAll(string uuid)
        {
            long logId = 0;
            try
            {
                logId = BaseApiManager.SaveLogs(uuid);
                if (!IsUuid(uuid)) { return Error(logId, "verify uuid fail！"); }
                var entityInterfaceAccount = GetInterfaceAccountByUuid(uuid);
                string companyId = entityInterfaceAccount.CompanyID;

                bool state = true;
                var lists = LinkGroupService.GetLinkGroupByState(SystemID, companyId, state.ToString());
                if (lists == null) { return Error(logId, "not data！"); }
                var data = from m in lists
                           orderby m.Sort
                           select new
                           {
                               id = m.GroupID,
                               name = m.Name,
                               sort = m.Sort.ToInt(),
                               external = m.IsExternal.ToBool()
                           };
                return Success(logId, "ok", data);


            }
            catch (Exception ex)
            {
                return Error(logId, ex.Message);
            }
        }
        [HttpGet("top")]
        [ActionName("list")]
        public IActionResult GetLinkTop(string uuid)
        {
            long logId = 0;
            try
            {
                logId = BaseApiManager.SaveLogs(uuid);
                if (!IsUuid(uuid)) { return Error(logId, "verify uuid fail！"); }
                var entityInterfaceAccount = GetInterfaceAccountByUuid(uuid);
                string companyId = entityInterfaceAccount.CompanyID;

                string groupId = Accessor.HttpContext.Request.GetQueryString("groupid");
                string typeId = Accessor.HttpContext.Request.GetQueryString("typeid");
                int count = Utility.ToPageIndex(Accessor.HttpContext.Request.GetQueryString("count").ToInt());
                string state = true.ToString();
                var lists = LinkService.GetLinkTop(SystemID, companyId, groupId, typeId, state, count);
                if (lists == null) { return Error(logId, "not data！"); }
                var data = from m in lists
                           orderby m.Sort
                           select new
                           {
                               id = m.GroupID,
                               group_id = m.GroupID,
                               group_name=m.GroupName,
                               type_id=m.TypeID.ToInt(),
                               type_name=m.TypeName,
                               name=m.Name,
                               logo=m.Logo,
                               url=m.Url,
                               sort=m.Sort.ToInt()
                           };
                return Success(logId, "ok", data);
            }
            catch (Exception ex)
            {
                return Error(logId, ex.Message);
            }
        }
        [HttpGet("paging")]
        [ActionName("list")]
        public IActionResult GetLinkPaging(string uuid)
        {
            long logId = 0;
            try
            {
                logId = BaseApiManager.SaveLogs(uuid);
                if (!IsUuid(uuid)) { return Error(logId, "verify uuid fail！"); }
                var entityInterfaceAccount = GetInterfaceAccountByUuid(uuid);
                string companyId = entityInterfaceAccount.CompanyID;

                string groupId = Accessor.HttpContext.Request.GetQueryString("groupid");
                string typeId = Accessor.HttpContext.Request.GetQueryString("typeid");
                int pageIndex = Utility.ToPageIndex(Utility.IsNum(Accessor.HttpContext.Request.GetQueryString("page"), 1));
                int pageCount = Utility.ToPageIndex(Utility.IsNum(Accessor.HttpContext.Request.GetQueryString("count"), 10));
                string state = true.ToString();
                long total = LinkService.CountLink(SystemID, companyId, groupId, typeId, state);
                var lists = LinkService.GetLinkPaging(SystemID, companyId, groupId, typeId, state, pageIndex, pageCount);
                if (lists == null) { return Error(logId, "not data！"); }
                var data = from m in lists
                           orderby m.Sort
                           select new
                           {
                               id = m.GroupID,
                               group_id = m.GroupID,
                               group_name = m.GroupName,
                               type_id = m.TypeID.ToInt(),
                               type_name = m.TypeName,
                               name = m.Name,
                               logo = m.Logo,
                               url = m.Url,
                               sort = m.Sort.ToInt()
                           };
                return Success(logId, "ok", new { page = pageIndex, total, rows = data });
            }
            catch (Exception ex)
            {
                return Error(logId, ex.Message);
            }
        }


    }
}