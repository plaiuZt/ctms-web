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
    using CTMS.Common.Utility;
    using CTMS.Common.Security;
    using CTMS.Common.Json;
    using CTMS.Web.Services;
    using CTMS.Web.Models;
    /// <summary>
    /// 公司员工管理控制器
    /// </summary>
    public class InstitutionStaffController : BaseController
    {
        private readonly IBaseManager BaseManager;
        private readonly IDepartmentService DepartmentService;
        private readonly IPositionService PositionService;
        private readonly IStoreService StoreService;
        private readonly IStaffService StaffService;
        private readonly ITableOperationManager<Institution_Staff> TableOperationManager;
        public InstitutionStaffController(IBaseManager BaseManager, IDepartmentService DepartmentService, IPositionService PositionService, IStoreService StoreService, IStaffService StaffService, ITableOperationManager<Institution_Staff> TableOperationManager) :base(BaseManager)
        {
            this.BaseManager = BaseManager;
            this.DepartmentService = DepartmentService;
            this.PositionService = PositionService;
            this.StoreService = StoreService;
            this.StaffService = StaffService;
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
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.员工管理.列表);
                if (!IsPermission(funcId))
                    return ToPermission(funcId);

                string startTime = GetQueryString("dateMin");
                string endTime = GetQueryString("dateMax");
                string keyword = GetQueryString("keyword");
                string departmentId = GetQueryString("departmentId");
                string positionId = GetQueryString("positionId");
                string storeId = GetQueryString("storeId");
                string warehouseId = GetQueryString("warehouseId");
                ViewBag.DateMin = startTime;
                ViewBag.DateMax = endTime;
                ViewBag.Keyword = keyword;

                int pageId = 1;
                int pageSize = 100;
                int rowCount = 0;
                List<Institution_Staff> lists = new List<Institution_Staff>();
                string strKeyword = string.Format("{0}{1}", keyword, startTime);
                if (string.IsNullOrWhiteSpace(strKeyword))
                    lists = StaffService.GetStaffPagingPro(SystemID, CompanyID, pageId, pageSize, out rowCount);
                else
                    lists = StaffService.SearchStaffPro(SystemID, CompanyID, startTime, endTime, departmentId, positionId, storeId, warehouseId, keyword);
                int totalNum = rowCount == 0 ? lists == null ? 0 : lists.Count() : rowCount;
                ViewBag.Count = totalNum;
                return View(lists);
            }
            catch (Exception ex)
            {
                return ToError(ex.Message);
            }
        }
        public IActionResult Add(string staffId = "")
        {
            try
            {
                string funcId = string.Empty;
                if (!IsAddPermission(staffId, out funcId)) { return ToPermission(funcId); }
                var entity = StaffService.GetStaffPro(SystemID, CompanyID, staffId);
                if (entity == null)
                    return View(new Institution_Staff());
                return View(entity);
            }
            catch (Exception ex)
            {
                return ToError(ex.Message);
            }
        }
        public IActionResult UpdatePassword(string staffId)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.员工管理.改密);
                if (!IsPermission(funcId))
                    return ToPermission(funcId);
                var entity = StaffService.GetStaffPro(SystemID, CompanyID, staffId);
                if (entity == null)
                    return ToError("staff id invalid！");
                return View(entity);
            }
            catch (Exception ex)
            {
                return ToError(ex.Message);
            }
        }

        #region 操作方法
        [HttpPost]
        public JsonResult Save(string staffId)
        {
            try
            {
                if (!IsSavePermission(staffId))
                    return Error("您没有操作权限，请联系系统管理员！");

                bool result = false;
                if (string.IsNullOrEmpty(staffId))
                    result = SaveStaff();
                else
                    result = UpdateStaff(staffId);
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
        public JsonResult UpdatePassword()
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.员工管理.改密);
                if (!IsPermission(funcId))
                    return Error("您没有操作权限，请联系系统管理员！");

                string staffId = GetQueryString("staffId");
                string newPassword = GetFormValue("fNewPassword");
                string confirmPassword = GetFormValue("fConfirmPassword");
                if (string.IsNullOrEmpty(staffId))
                    return Error("员工工号不能为空！");
                if (confirmPassword.Length < 6)
                    return Error("密码长度不能少于6位字符！");
                if (newPassword != confirmPassword)
                    return Error("输入的二次密码不相同！");
                string password = AlgorithmHelper.MD5(confirmPassword).ToLower();
                var entity = StaffService.GetStaffPro(SystemID, CompanyID, staffId);
                var result = StaffService.UpdateStaffPasswordPro(SystemID, CompanyID, staffId, password);
                string newEntityJson = GetNewEntityJson(entity, password);
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
        public JsonResult UpdateState(string staffId, bool state)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.员工管理.审核);
                if (!IsPermission(funcId))
                    return Error("您没有操作权限，请联系系统管理员！");
                var entity = StaffService.GetStaffPro(SystemID, CompanyID, staffId);
                var result = StaffService.UpdateStaffStatePro(SystemID, CompanyID, staffId, state);
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
        public JsonResult Delete(string staffId)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.员工管理.删除);
                if (!IsPermission(funcId))
                    return Error("您没有操作权限，请联系系统管理员！");
                var entity = StaffService.GetStaffPro(SystemID, CompanyID, staffId);
                var result = StaffService.DeleteStaffPro(SystemID, CompanyID, staffId);
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
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.员工管理.删除);
                if (!IsPermission(funcId))
                    return Error("您没有操作权限，请联系系统管理员！");
                if (arrId.Length == 0)
                    return Error("请选择删除ID!");
                List<object> lists = new List<object>();
                foreach (var item in arrId)
                {
                    string staffId = item;
                    if (staffId != StaffID)
                    {
                        try
                        {
                            var entity = StaffService.GetStaffPro(SystemID, CompanyID, staffId);
                            bool result = StaffService.DeleteStaffPro(SystemID, CompanyID, staffId);
                            TableOperationManager.Delete(entity, result);
                            lists.Add(new { staff_id = staffId, result, message = "ok" });
                        }
                        catch (Exception ex)
                        {
                            lists.Add(new { staff_id = staffId, result = false, message = ex.Message });
                        }
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

        #region 辅助方法
        [HttpGet]
        [ActionName("position-list-get")]
        public JsonResult GetPosition()
        {
            try
            {
                string state = "true";
                var lists = PositionService.GetPositionByStatePro(SystemID, CompanyID, state);
                if (lists == null)
                    return Error("not data！");
                var data = from m in lists
                           select new
                           {
                               position_id = m.PositionID,
                               position_name = m.PositionName
                           };
                return Success("ok", data);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        [HttpGet]
        [ActionName("store-list-get")]
        public JsonResult GetStore()
        {
            try
            {
                string state = "true";
                var lists = StoreService.GetStoreByStatePro(SystemID, CompanyID, state);
                if (lists == null)
                    return Error("not data！");
                var data = from m in lists
                           select new
                           {
                               store_id = m.StoreID,
                               store_name = m.StoreName
                           };
                return Success("ok", data);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        [HttpGet]
        [ActionName("department-list-get")]
        public JsonResult Getdepartment()
        {
            try
            {
                string departmentId = "0";
                string state = "true";
                var lists = DepartmentService.GetDepartmentByNodePathPro(SystemID, CompanyID, departmentId, state);
                if (lists == null)
                    return Error("not data！");
                var data = from m in lists
                           select new
                           {
                               department_id = m.DepartmentID,
                               department_name = m.DepartmentName,
                               level = m.RankID,
                               space = Utility.StringRepeat("　", m.RankID.ToInt() - 1),
                               level_symbol = m.RankID.ToInt() > 1 ? "" : ""
                           };
                return Success("ok", data);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        #endregion

        #region 私有方法
        private bool SaveStaff()
        {
            try
            {
                string fStaffId = GetFormValue("fStaffId");
                string fStaffName = GetFormValue("fStaffName");
                string fSex = GetFormValue("fSex");
                string fPositionId = GetFormValue("fPositionId");
                string fDepartmentId = GetFormValue("fDepartmentId");
                string fStoreId = GetFormValue("fStoreId");
                string fPhone = GetFormValue("fPhone");
                string fEmail = GetFormValue("fEmail");
                string fAddress = GetFormValue("fAddress");
                string fDescription = GetFormValue("fDescription");
                string fState = GetFormValue("fState");

                if (string.IsNullOrWhiteSpace(fStaffId))
                    throw new Exception("员工工号不能为空！");
                if (string.IsNullOrWhiteSpace(fStaffName))
                    throw new Exception("员工姓名不能为空！");
                if (fPhone.Length != 11)
                    throw new Exception("手机号码长度错误！");
                if (!Utility.IsMobilePhone(fPhone))
                    throw new Exception("手机号码格式错误！");

                string password = AlgorithmHelper.MD5(Utility.Right(fPhone, 8)).ToLower();
                var entity = new Institution_Staff()
                {
                    SystemID = SystemID,
                    CompanyID = CompanyID,
                    StaffID = fStaffId,
                    StaffName = fStaffName,
                    UserName = fStaffId,
                    Password = password,
                    NickName = fStaffName,
                    Name = fStaffName,
                    Sex = fSex.ToByte(),
                    Phone = fPhone,
                    Email = fEmail,
                    Address = fAddress,
                    DepartmentID = fDepartmentId,
                    PositionID = fPositionId,
                    StoreID = fStoreId,
                    WarehouseID = "",
                    Description = fDescription,
                    IsInit = false,
                    State = fState.ToBool(),
                    IsDel = false,
                    CreateDate = DateTime.Now
                };
                bool result = StaffService.SaveStaffPro(entity);
                TableOperationManager.Add(entity, result);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private bool UpdateStaff(string staffId)
        {
            try
            {
                string fStaffName = GetFormValue("fStaffName");
                string fSex = GetFormValue("fSex");
                string fPositionId = GetFormValue("fPositionId");
                string fDepartmentId = GetFormValue("fDepartmentId");
                string fStoreId = GetFormValue("fStoreId");
                string fPhone = GetFormValue("fPhone");
                string fEmail = GetFormValue("fEmail");
                string fAddress = GetFormValue("fAddress");
                string fDescription = GetFormValue("fDescription");
                string fState = GetFormValue("fState");

                if (string.IsNullOrWhiteSpace(fStaffName))
                    throw new Exception("员工姓名不能为空！");
                if (fPhone.Length != 11)
                    throw new Exception("手机号码长度错误！");
                if (!Utility.IsMobilePhone(fPhone))
                    throw new Exception("手机号码格式错误！");
                var entity = StaffService.GetStaffPro(SystemID, CompanyID, staffId);
                if (entity == null)
                    throw new Exception("员工工号不存在！");
                Institution_Staff m = new Institution_Staff()
                {
                    SystemID=entity.SystemID,
                    CompanyID=entity.CompanyID,
                    StaffID=entity.StaffID,
                    StaffName = fStaffName,
                    UserName=entity.UserName,
                    Password=entity.Password,
                    NickName = fStaffName,
                    HeadImgUrl=entity.HeadImgUrl,
                    Name = fStaffName,
                    Sex = fSex.ToByte(),
                    BirthDate=entity.BirthDate,
                    BirthPlace=entity.BirthPlace,
                    Identification=entity.Identification,
                    Education=entity.Education,
                    Phone = fPhone,
                    QQ=entity.QQ,
                    Weixin=entity.Weixin,
                    Email = fEmail,
                    Address = fAddress,
                    Wages=entity.Wages,
                    Probation=entity.Probation,
                    StartWorkDate=entity.StartWorkDate,
                    EndWorkDate=entity.EndWorkDate,
                    SignContractDate=entity.SignContractDate,
                    ExpirationContractDate=entity.ExpirationContractDate,
                    DepartmentID = fDepartmentId,
                    DepartmentName=entity.DepartmentName,
                    PositionID = fPositionId,
                    PositionName=entity.PositionName,
                    StoreID = fStoreId,
                    StoreName=entity.StoreName,
                    WarehouseID=entity.WarehouseID,
                    WarehouseName=entity.WarehouseName,
                    Description = fDescription,
                    IsInit=entity.IsInit,
                    State = fState.ToBool(),
                    IsDel=entity.IsDel,
                    CreateDate=entity.CreateDate
                };
                bool result= StaffService.UpdateStaffPro(m);
                string newEntityJson = GetNewEntityJson(entity, fStaffName, fSex, fPositionId, fDepartmentId, fStoreId, fPhone, fEmail, fAddress, fDescription, fState);
                TableOperationManager.Update(entity, newEntityJson, result);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool IsSavePermission(string storeId)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(storeId))
                {
                    string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.员工管理.新增);
                    return IsPermission(funcId) ? true : false;
                }
                else
                {
                    string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.员工管理.编辑);
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
                    funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.员工管理.新增);
                    return IsPermission(funcId) ? true : false;
                }
                else
                {
                    funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.员工管理.编辑);
                    return IsPermission(funcId) ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private string GetNewEntityJson(Institution_Staff entity, string fStaffName, string fSex, string fPositionId, string fDepartmentId, string fStoreId, string fPhone, string fEmail, string fAddress, string fDescription, string fState)
        {
            try
            {
                Institution_Staff m = entity.ToJson().ToObject<Institution_Staff>();
                m.StaffName = fStaffName;
                m.NickName = fStaffName;
                m.Sex = fSex.ToByte();
                m.Name = fStaffName;
                m.Phone = fPhone;
                m.Email = fEmail;
                m.Address = fAddress;
                m.DepartmentID = fDepartmentId;
                m.PositionID = fPositionId;
                m.StoreID = fStoreId;
                m.Description = fDescription;
                m.State = fState.ToBool();
                return m.ToJson();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private string GetNewEntityJson(Institution_Staff entity, string password)
        {
            try
            {
                Institution_Staff m = entity.ToJson().ToObject<Institution_Staff>();
                m.Password = password;
                return m.ToJson();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private string GetNewEntityJson(Institution_Staff entity, bool state)
        {
            try
            {
                Institution_Staff m = entity.ToJson().ToObject<Institution_Staff>();
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