using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CTMS.Web.Controllers.MVC.Extend
{
    using CTMS.DbModels;
    using CTMS.IService.Extend;
    using CTMS.Common.Extension;
    using CTMS.Common.Utility;
    using CTMS.Common.Web;
    using CTMS.Web.Models;
    using CTMS.Web.Services;

    [AdminAuthorize(Roles = "Admins")]
    public class ExtendAdvertisementController : BaseController
    {
        private readonly IBaseManager BaseManager;
        private readonly IAdvertisementService AdvertisementService;
        private readonly IAdvertisementDetailsService AdvertisementDetailsService;
        public ExtendAdvertisementController(IBaseManager BaseManager, IAdvertisementService AdvertisementService, IAdvertisementDetailsService AdvertisementDetailsService) : base(BaseManager)
        {
            this.BaseManager = BaseManager;
            this.AdvertisementService = AdvertisementService;
            this.AdvertisementDetailsService = AdvertisementDetailsService;
        }
        public override IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.扩展管理.广告管理.列表);
                if (!IsPermission(funcId)) { return ToPermission(funcId); }

                string startTime = GetQueryString("datemin");
                string endTime = GetQueryString("datemax");
                string state = GetQueryString("state");
                string keyword = GetQueryString("keyword");
                ViewData["DateMin"] = startTime;
                ViewData["DateMax"] = endTime;
                ViewData["State"] = state;
                ViewData["Keyword"] = keyword;

                int total = 100;
                List<Extend_Advertisement> lists = new List<Extend_Advertisement>();
                string strKeyword = string.Format("{0}{1}", startTime, keyword);
                if (string.IsNullOrWhiteSpace(strKeyword))
                    lists = AdvertisementService.GetAdvertisementTop(SystemID, CompanyID, total);
                else
                    lists = AdvertisementService.SearchAdvertisement(SystemID, CompanyID, startTime, endTime, state, keyword, total);
                ViewData["Count"] = AdvertisementService.CountAdvertisement(SystemID, CompanyID);
                return View(lists);
            }
            catch (Exception ex)
            {
                return ToError(ex.Message);
            }
        }
        public IActionResult Add(string advertisementId)
        {
            try
            {
                string funcId = string.Empty;
                if (!IsAddPermission(advertisementId, out funcId)) { return ToPermission(funcId); }

                if (string.IsNullOrWhiteSpace(advertisementId))
                    return View(new Extend_Advertisement());
                var entity = AdvertisementService.GetAdvertisement(SystemID, CompanyID, advertisementId);
                if (entity == null)
                    return View(new Extend_Advertisement());
                return View(entity);
            }
            catch (Exception ex)
            {
                return ToError(ex.Message);
            }
        }
        public JsonResult GetAdvertisementDetails(string advertisementId)
        {
            try
            {
                var lists = AdvertisementDetailsService.GetAdvertisementDetailsByAdvertisementId(SystemID, CompanyID, advertisementId);
                if (lists == null) { return Error("not date！"); }
                var data = from m in lists
                           select new
                           {
                               id = m.DetailsID,
                               title = m.Title.IIF(string.Empty),
                               remark = m.Remark.IIF(string.Empty),
                               media_id = m.MediaID,
                               media_type = m.MediaType,
                               media_path = m.MediaPath,
                               url = m.Url.IIF(string.Empty),
                               sort = m.Sort.ToInt(),
                               state = m.State.ToBool(),
                               date = m.CreateDate.ToDate().ToString("yyyy-MM-dd HH:mm")
                           };
                return Success("ok", data);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [HttpPost]
        [ActionName("UpdateState")]
        public JsonResult UpdateState(string advertisementId)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.扩展管理.广告管理.审核);
                if (!IsPermission(funcId)) { return Error("您没有操作权限，请联系系统管理员！"); }

                bool state = GetFormValue("state").ToBool();
                var result = AdvertisementService.UpdateAdvertisementState(SystemID, CompanyID, advertisementId, state);
                if (result)
                    return Success("ok");
                else
                    return Error("fail");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public JsonResult Delete(string advertisementId)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.扩展管理.广告管理.删除);
                if (!IsPermission(funcId)) { return Error("您没有操作权限，请联系系统管理员！"); }

                var result = AdvertisementService.DeleteAdvertisement(SystemID, CompanyID, advertisementId);
                if (result)
                    return Success("ok");
                else
                    return Error("fail");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        [HttpPost]
        [ActionName("DeleteBatch")]
        public JsonResult DeleteBatch(string[] arrId)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.扩展管理.广告管理.删除);
                if (!IsPermission(funcId)) { return Error("您没有操作权限，请联系系统管理员！"); }

                if (arrId.Length == 0)
                    return Error("请选择删除ID!");
                List<object> lists = new List<object>();
                foreach (var item in arrId)
                {
                    string advertisementId = item.ToString();
                    try
                    {
                        bool result = AdvertisementService.DeleteAdvertisement(SystemID, CompanyID, advertisementId);
                        lists.Add(new { advertisement_id = advertisementId, result, message = "ok" });
                    }
                    catch (Exception ex)
                    {
                        lists.Add(new { advertisement_id = advertisementId, result = false, message = ex.Message });
                    }
                }
                return Success("成功！", lists);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        [HttpPost]
        [ActionName("DeleteDetails")]
        public JsonResult DeleteDetails(string DetailsId)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.扩展管理.广告管理.删除);
                if (!IsPermission(funcId)) { return Error("您没有操作权限，请联系系统管理员！"); }

                var result = AdvertisementDetailsService.DeleteAdvertisementDetails(SystemID, CompanyID, DetailsId);
                if (result)
                    return Success("ok");
                else
                    return Error("fail");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        [HttpPost]
        [ActionName("Save")]
        public JsonResult Save(string advertisementId)
        {
            try
            {
                string funcId = string.Empty;
                if (!IsSavePermission(advertisementId)) { return Error("您没有操作权限，请联系系统管理员！"); }

                string fName = GetFormValue("fName");
                string fRemark = GetFormValue("fRemark");
                string fSort = GetFormValue("fSort");
                string fState = GetFormValue("fState");

                string fDetailsMediaId = GetFormValueArr("fDetailsMediaId");
                string fDetailsMediaPath = GetFormValueArr("fDetailsMediaPath");
                string fDetailsTitle = GetFormValueArr("fDetailsTitle");
                string fDetailsUrl = GetFormValueArr("fDetailsUrl");

                string[] DetailsMediaId = fDetailsMediaId.Split(",");
                string[] DetailsMediaPath = fDetailsMediaPath.Split(",");
                string[] DetailsTitle = fDetailsTitle.Split(",");
                string[] DetailsUrl = fDetailsUrl.Split(",");
                Extend_Advertisement entity = new Extend_Advertisement()
                {
                    SystemID = SystemID,
                    CompanyID = CompanyID,
                    AdvertisementID = advertisementId,
                    Name = fName,
                    Remark = fRemark,
                    Sort = fSort.ToInt(),
                    State = fState.ToBool()
                };
                List<Extend_AdvertisementDetails> lists = new List<Extend_AdvertisementDetails>();
                for(var i=0;i< DetailsMediaId.Length; i++)
                {
                    lists.Add(new Extend_AdvertisementDetails()
                    {
                        Title = DetailsTitle[i].ToString(),
                        MediaID = DetailsMediaId[i].ToString(),
                        MediaPath = DetailsMediaPath[i].ToString(),
                        Url = DetailsUrl[i].ToString(),
                        Sort = 0,
                        State = true
                    });
                }
                var result = false;
                if (string.IsNullOrEmpty(advertisementId))
                    result = AdvertisementService.SaveAdvertisement(entity, lists);
                else
                    result = AdvertisementService.UpdateAdvertisement(entity, lists);
                if (result)
                    return Success("ok");
                else
                    return Error("fail");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        #region 私有化方法
        public bool IsSavePermission(string linkId)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(linkId))
                {
                    string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.扩展管理.广告管理.新增);
                    return IsPermission(funcId) ? true : false;
                }
                else
                {
                    string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.扩展管理.广告管理.编辑);
                    return IsPermission(funcId) ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool IsAddPermission(string linkId, out string funcId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(linkId))
                {
                    funcId = PermissionEnum.CodeFormat((int)PermissionEnum.扩展管理.广告管理.新增);
                    return IsPermission(funcId) ? true : false;
                }
                else
                {
                    funcId = PermissionEnum.CodeFormat((int)PermissionEnum.扩展管理.广告管理.编辑);
                    return IsPermission(funcId) ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


    }
}