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
    /// 公司职位管理控制器 已完成
    /// </summary>
    [AdminAuthorize(Roles = "Admins")]
    public class InstitutionPositionController : BaseController
    {
        private readonly IBaseManager BaseManager;
        private readonly IDepartmentService DepartmentService;
        private readonly IPositionService PositionService;
        private readonly ITableOperationManager<Institution_Position> TableOperationManager;
        public InstitutionPositionController(IBaseManager BaseManager, IDepartmentService DepartmentService, IPositionService PositionService, ITableOperationManager<Institution_Position> TableOperationManager) : base(BaseManager)
        {
            this.BaseManager = BaseManager;
            this.DepartmentService = DepartmentService;
            this.PositionService = PositionService;
            this.TableOperationManager = TableOperationManager;
            TableOperationManager.Account = StaffID;
            TableOperationManager.NickName = StaffName;
        }
        public override IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.职位管理.列表);
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
                List<Institution_Position> lists = new List<Institution_Position>();
                string strKeyword = string.Format("{0}{1}", keyword, startTime);
                if (string.IsNullOrWhiteSpace(strKeyword))
                    lists = PositionService.GetPositionPagingPro(SystemID, CompanyID, pageId, pageSize, out rowCount);
                else
                    lists = PositionService.SearchPositionPro(SystemID, CompanyID, startTime, endTime, keyword);
                int totalNum = rowCount == 0 ? lists == null ? 0 : lists.Count() : rowCount;
                ViewBag.Count = totalNum;
                return View(lists);

            }
            catch (Exception ex)
            {
                return ToError(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Add(string positionId = "")
        {
            try
            {
                string funcId = "";
                if (!IsAddPermission(positionId, out funcId))
                    return ToPermission(funcId);
                if (string.IsNullOrWhiteSpace(positionId))
                    return View(new Institution_Position());
                var entity = PositionService.GetPositionPro(SystemID, CompanyID, positionId);
                if (entity == null)
                    return View(new Institution_Position());
                return View(entity);
            }
            catch (Exception ex)
            {
                return ToError(ex.Message);
            }
        }

        #region 操作方法
        [HttpPost]
        public JsonResult Save(string positionId)
        {
            try
            {
                if (!IsSavePermission(positionId))
                    return Error("您没有操作权限，请联系系统管理员！");

                string fPositionId = GetFormValue("fPositionId");
                string fPositionName = GetFormValue("fPositionName");
                string fSort = GetFormValue("fSort");
                string fDescription = GetFormValue("fDescription");
                string fState = GetFormValue("fState");

                if (string.IsNullOrEmpty(positionId))
                {
                    if (string.IsNullOrWhiteSpace(fPositionId))
                        return Error("职位编号不能为空！");
                    else
                    {
                        if (fPositionId.Length > 6)
                            return Error("职位编号必是6位数字！");
                    }
                    fPositionId = fPositionId.PadLeft(6, '0');
                }
                int sort = fSort.ToInt();
                bool state = fState.ToBool();
                bool result = false;
                if (string.IsNullOrEmpty(positionId))
                {
                    result = PositionService.SavePositionPro(SystemID, CompanyID, fPositionId, fPositionName, fDescription, sort, state);
                    var entity = PositionService.GetPositionPro(SystemID, CompanyID, fPositionId);
                    TableOperationManager.Add(entity, result);
                }
                else
                {
                    var entity = PositionService.GetPositionPro(SystemID, CompanyID, positionId);
                    result = PositionService.UpdatePositionPro(SystemID, CompanyID, positionId, fPositionName, fDescription, sort, state);
                    string newEntityJson = GetNewEntityJson(entity, fPositionName, fDescription, sort, state);
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
        public JsonResult UpdateState(string positionId, bool state)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.职位管理.审核);
                if (!IsPermission(funcId))
                    return Error("您没有操作权限，请联系系统管理员！");
                var entity = PositionService.GetPositionPro(SystemID, CompanyID, positionId);
                var result = PositionService.UpdatePositionStatePro(SystemID, CompanyID, positionId, state);
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
        public JsonResult Delete(string positionId)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.职位管理.删除);
                if (!IsPermission(funcId)) { return Error("您没有操作权限，请联系系统管理员！"); }
                    
                var entity = PositionService.GetPositionPro(SystemID, CompanyID, positionId);
                var result = PositionService.DeletePositionPro(SystemID, CompanyID, positionId);
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
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.职位管理.删除);
                if (!IsPermission(funcId))
                    return Error("您没有操作权限，请联系系统管理员！");
                if (arrId.Length == 0)
                    return Error("请选择删除ID!");
                List<object> lists = new List<object>();
                foreach (var item in arrId)
                {
                    string positionId = item;
                    try
                    {
                        var entity = PositionService.GetPositionPro(SystemID, CompanyID, positionId);
                        bool result = PositionService.DeletePositionPro(SystemID, CompanyID, positionId);
                        TableOperationManager.Delete(entity, result);
                        lists.Add(new { position_id = positionId, result, message = "ok" });
                    }
                    catch (Exception ex)
                    {
                        lists.Add(new { position_id = positionId, result = false, message = ex.Message });
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
        public bool IsSavePermission(string positionId)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(positionId))
                {
                    string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.职位管理.新增);
                    return IsPermission(funcId) ? true : false;
                }
                else
                {
                    string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.职位管理.编辑);
                    return IsPermission(funcId) ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool IsAddPermission(string positionId, out string funcId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(positionId))
                {
                    funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.职位管理.新增);
                    return IsPermission(funcId) ? true : false;
                }
                else
                {
                    funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.职位管理.编辑);
                    return IsPermission(funcId) ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private string GetNewEntityJson(Institution_Position entity, bool state)
        {
            try
            {
                Institution_Position m = entity.ToJson().ToObject<Institution_Position>();
                m.State = state;
                return m.ToJson();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private string GetNewEntityJson(Institution_Position entity, string positionName, string description, int sort,bool state)
        {
            try
            {
                Institution_Position m = entity.ToJson().ToObject<Institution_Position>();
                m.PositionName = positionName;
                m.Description = description;
                m.Sort = sort;
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