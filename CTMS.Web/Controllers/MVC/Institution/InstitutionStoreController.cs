using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CTMS.Web.Controllers.MVC.Institution
{
    using CTMS.DbModels;
    using CTMS.IService.Institution;
    using CTMS.Common.Extension;
    using CTMS.Common.Json;
    using CTMS.Web.Services;
    using CTMS.Web.Models;
    /// <summary>
    /// 公司网点管理控制器 已完成
    /// </summary>
    public class InstitutionStoreController : BaseController
    {
        private readonly IBaseManager BaseManager;
        private readonly IStoreService StoreService;
        private readonly ITableOperationManager<Institution_Store> TableOperationManager;
        public InstitutionStoreController(IBaseManager BaseManager, IStoreService StoreService, ITableOperationManager<Institution_Store> TableOperationManager) :base(BaseManager)
        {
            this.BaseManager = BaseManager;
            this.StoreService = StoreService;
            this.TableOperationManager = TableOperationManager;
            TableOperationManager.Account = StaffID;
            TableOperationManager.NickName = StaffName;
        }
        public override IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.网点管理.列表);
                if (!IsPermission(funcId))
                    return ToPermission(funcId);

                string startTime = GetQueryString("datemin");
                string endTime = GetQueryString("datemax");
                string keyword = GetQueryString("keyword");
                ViewBag.datemin = startTime;
                ViewBag.datemax = endTime;
                ViewBag.keyword = keyword;

                int pageId = 1;
                int pageSize = 100;
                int rowCount = 0;
                List<Institution_Store> lists = new List<Institution_Store>();
                string strKeyword = string.Format("{0}{1}", keyword, startTime);
                if (string.IsNullOrWhiteSpace(strKeyword))
                    lists = StoreService.GetStorePagingPro(SystemID, CompanyID, pageId, pageSize, out rowCount);
                else
                    lists = StoreService.SearchStorePro(SystemID, CompanyID, startTime, endTime, keyword);
                int totalNum = rowCount == 0 ? lists == null ? 0 : lists.Count() : rowCount;
                ViewBag.Count = totalNum;
                return View(lists);

            }
            catch (Exception ex)
            {
                return ToError(ex.Message);
            }
        }
        public IActionResult Add(string storeId = "")
        {
            try
            {
                string funcId = "";
                if (!IsAddPermission(storeId, out funcId))
                    return ToPermission(funcId);
                if (string.IsNullOrWhiteSpace(storeId))
                    return View(new Institution_Store());
                var entity = StoreService.GetStorePro(SystemID, CompanyID, storeId);
                if (entity == null)
                    return View(new Institution_Store());
                return View(entity);
            }
            catch (Exception ex)
            {
                return ToError(ex.Message);
            }
        }

        #region 操作方法
        [HttpPost]
        public JsonResult Save(string storeId)
        {
            try
            {
                if (!IsSavePermission(storeId))
                    return Error("您没有操作权限，请联系系统管理员！");

                string fStoreId = GetFormValue("fStoreId");
                string fStoreName = GetFormValue("fStoreName");
                string fContacts = GetFormValue("fContacts");
                string fphone = GetFormValue("fphone");
                string fTel = GetFormValue("fTel");
                string fFax = GetFormValue("fFax");
                string fEmail = GetFormValue("fEmail");
                string fProvinceId = GetFormValue("fProvinceId");
                string fCityId = GetFormValue("fCityId");
                string fAreaId = GetFormValue("fAreaId");
                string fAddress = GetFormValue("fAddress");
                string fSort = GetFormValue("fSort");
                string fDescription = GetFormValue("fDescription");
                string fState = GetFormValue("fState");

                string logo = "";
                string keyword = fDescription.Left(100);
                DateTime startTime = DateTime.Now;
                DateTime endTime = DateTime.Now.AddYears(10);
                int provinceId = fProvinceId.ToInt();
                int cityId = fCityId.ToInt();
                int areaId = fAreaId.ToInt();
                int sort = fSort.ToInt();
                bool push = false;
                bool state = fState.ToBool();
                if (string.IsNullOrEmpty(storeId))
                {
                    if (string.IsNullOrWhiteSpace(fStoreId))
                        return Error("网点编号不能为空！");
                    else
                    {
                        if (fStoreId.Length > 6)
                            return Error("网点编号必是6位数字！");
                    }
                    fStoreId = fStoreId.PadLeft(6, '0');
                }
                bool result = false;
                if (string.IsNullOrEmpty(storeId))
                {
                    result = StoreService.SaveStorePro(SystemID, CompanyID, fStoreId, fStoreName, logo, fContacts, fTel, fFax, fphone, fEmail, provinceId, cityId, areaId, fAddress, keyword, fDescription, startTime, endTime, push, sort, state);
                    var entity = StoreService.GetStorePro(SystemID, CompanyID, fStoreId);
                    TableOperationManager.Add(entity, result);
                }
                else
                {
                    var entity = StoreService.GetStorePro(SystemID, CompanyID, storeId);
                    result = StoreService.UpdateStorePro(SystemID, CompanyID, storeId, fStoreName, logo, fContacts, fTel, fFax, fphone, fEmail, provinceId, cityId, areaId, fAddress, keyword, fDescription, startTime, endTime, push, sort, state);
                    string newEntityJson = GetNewEntityJson(entity, fStoreName, logo, fContacts, fTel, fFax, fphone, fEmail, provinceId, cityId, areaId, fAddress, keyword, fDescription, startTime, endTime, push, sort, state);
                    TableOperationManager.Update(entity, newEntityJson, result);
                }
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
        public JsonResult UpdateState(string storeId, bool state)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.网点管理.审核);
                if (!IsPermission(funcId))
                    return Error("您没有操作权限，请联系系统管理员！");
                var entity = StoreService.GetStorePro(SystemID, CompanyID, storeId);
                var result = StoreService.UpdateStoreStatePro(SystemID, CompanyID, storeId, state);
                string newEntityJson = GetNewEntityJson(entity, state);
                TableOperationManager.Update(entity, newEntityJson, result);
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
        public JsonResult Delete(string storeId)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.网点管理.删除);
                if (!IsPermission(funcId))
                    return Error("您没有操作权限，请联系系统管理员！");
                var entity = StoreService.GetStorePro(SystemID, CompanyID, storeId);
                var result = StoreService.DeleteStorePro(SystemID, CompanyID, storeId);
                TableOperationManager.Delete(entity, result);
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
        public JsonResult DeleteBatch(string[] arrId)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.网点管理.删除);
                if (!IsPermission(funcId))
                    return Error("您没有操作权限，请联系系统管理员！");

                if (arrId.Length == 0)
                    return Error("请选择删除ID!");
                List<object> lists = new List<object>();
                foreach (var item in arrId)
                {
                    string storeId = item;
                    try
                    {
                        var entity = StoreService.GetStorePro(SystemID, CompanyID, storeId);
                        bool result = StoreService.DeleteStorePro(SystemID, CompanyID, storeId);
                        TableOperationManager.Delete(entity, result);
                        lists.Add(new { store_id = storeId, result, message = "ok" });
                    }
                    catch (Exception ex)
                    {
                        lists.Add(new { store_id = storeId, result = false, message = ex.Message });
                    }
                }
                return Success("成功！", lists);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        #endregion

        #region 私有化方法
        public bool IsSavePermission(string storeId)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(storeId))
                {
                    string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.网点管理.新增);
                    return IsPermission(funcId) ? true : false;
                }
                else
                {
                    string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.网点管理.编辑);
                    return IsPermission(funcId) ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool IsAddPermission(string storeId, out string funcId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(storeId))
                {
                    funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.网点管理.新增);
                    return IsPermission(funcId) ? true : false;
                }
                else
                {
                    funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.网点管理.编辑);
                    return IsPermission(funcId) ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private string GetNewEntityJson(Institution_Store entity, bool state)
        {
            try
            {
                Institution_Store m = entity.ToJson().ToObject<Institution_Store>();
                m.State = state;
                return m.ToJson();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private string GetNewEntityJson(Institution_Store entity, string storeName, string logo, string contacts, string tel, string fax, string phone, string email, int provinceId, int cityId, int areaId, string address, string keyword, string description, DateTime startTime, DateTime endTime, bool push, int sort, bool state)
        {
            try
            {
                Institution_Store m = entity.ToJson().ToObject<Institution_Store>();
                m.StoreName = storeName;
                m.Logo = logo;
                m.Contacts = contacts;
                m.Tel = tel;
                m.Fax = fax;
                m.Phone = phone;
                m.Email = email;
                m.ProvinceID = provinceId;
                m.CityID = cityId;
                m.AreaID = areaId;
                m.Address = address;
                m.Keyword = keyword;
                m.Description = description;
                m.StartTime = startTime.ToDate();
                m.EndTime = endTime.ToDate();
                m.Push = push.ToBool();
                m.Sort = sort.ToInt();
                m.State = state;
                return m.ToJson();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}