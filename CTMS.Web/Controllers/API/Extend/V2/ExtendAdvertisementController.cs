using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace CTMS.Web.Controllers.API.Extend.V2
{
    using CTMS.Common.Extension;
    using CTMS.Common.Utility;
    using CTMS.DbModels;
    using CTMS.IService.Extend;
    using CTMS.Web.Services;
    
    [ApiVersion("2.0")]
    [EnableCors("AllowSameDomain")]
    [ControllerName("extend/advertisement")]
    public class ExtendAdvertisementController : BaseApiController
    {
        private readonly IBaseApiManager BaseApiManager;
        private readonly IHttpContextAccessor Accessor;
        private readonly IAdvertisementService AdvertisementService;
        private readonly IAdvertisementDetailsService AdvertisementDetailsService;

        public ExtendAdvertisementController(IBaseApiManager BaseApiManager, IHttpContextAccessor Accessor, IAdvertisementService AdvertisementService, IAdvertisementDetailsService AdvertisementDetailsService) : base(BaseApiManager)
        {
            this.BaseApiManager = BaseApiManager;
            this.Accessor = Accessor;
            this.AdvertisementService = AdvertisementService;
            this.AdvertisementDetailsService = AdvertisementDetailsService;
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
        [ActionName("get")]
        public IActionResult GetAdvertisement(string uuid)
        {
            long logId = 0;
            try
            {
                logId = BaseApiManager.SaveLogs(uuid);
                if (!IsUuid(uuid)) { return Error(logId, "verify uuid fail！"); }
                var entityInterfaceAccount = GetInterfaceAccountByUuid(uuid);
                string companyId = entityInterfaceAccount.CompanyID;

                string advertisementId = Accessor.HttpContext.Request.GetQueryString("id");
                var entity = AdvertisementService.GetAdvertisement(SystemID, companyId, advertisementId);
                if (entity == null) { return Error(logId, "not data！"); }
                var details = AdvertisementDetailsService.GetAdvertisementDetailsByAdvertisementId(SystemID, companyId, advertisementId);
                var data = new
                {
                    id = entity.AdvertisementID,
                    name = entity.Name,
                    remark = entity.Remark.IIF(),
                    details = ToDetails(details)
                };
                return Success(logId, "ok", data);
            }
            catch (Exception ex)
            {
                return Error(logId, ex.Message);
            }
        }

        #region 私有化方法
        private object ToDetails(List<Extend_AdvertisementDetails> lists)
        {
            try
            {
                return from m in lists
                       where m.State.Value
                       orderby m.Sort
                       select new
                       {
                           title = m.Title.IIF(),
                           description = m.Remark.IIF(),
                           src = m.MediaPath,
                           url = m.Url,
                           sort = m.Sort.ToInt()
                       };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}