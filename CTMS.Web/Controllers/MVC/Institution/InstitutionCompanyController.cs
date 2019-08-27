using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    /// 公司资料管理控制器 已完成
    /// </summary>
    [AdminAuthorize(Roles = "Admins")]
    public class InstitutionCompanyController : BaseController
    {
        private readonly IBaseManager BaseManager;
        private readonly ICompanyService CompanyService;
        private readonly ITableOperationManager<Institution_Company> TableOperationManager;

        public InstitutionCompanyController(IBaseManager BaseManager, ICompanyService CompanyService, ITableOperationManager<Institution_Company> TableOperationManager) :base(BaseManager)
        {
            this.BaseManager = BaseManager;
            this.CompanyService = CompanyService;
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
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.资料管理.列表);
                if (!IsPermission(funcId))
                    return ToPermission(funcId);

                string startTime = GetQueryString("datemin");
                string endTime = GetQueryString("datemax");
                string keyword = GetQueryString("keyword");
                ViewBag.datemin = startTime;
                ViewBag.datemax = endTime;
                ViewBag.keyword = keyword;
                
                List<Institution_Company> lists = new List<Institution_Company>();
                if (string.IsNullOrWhiteSpace(keyword) && string.IsNullOrWhiteSpace(startTime))
                    lists.Add(CompanyService.GetCompanyPro(SystemID, CompanyID));
                else
                    lists = CompanyService.SearchCompanyPro(SystemID, CompanyID, startTime, endTime, keyword);
                int totalNum = lists == null ? 0 : lists.Count();
                ViewBag.Count = totalNum;
                return View(lists);
            }
            catch (Exception ex)
            {
                return ToError(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Edit(string companyId)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.资料管理.编辑);
                if (!IsPermission(funcId))
                    return ToPermission(funcId);
                var entity = CompanyService.GetCompanyPro(SystemID, companyId);
                return View(entity);
            }
            catch (Exception ex)
            {
                return ToError(ex.Message);
            }
        }

        #region 操作方法
        [HttpPost]
        public JsonResult Update(string companyId)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.公司管理.资料管理.编辑);
                if (!IsPermission(funcId))
                    return Error("您没有操作权限，请联系系统管理员！");
                string companyName = GetFormValue("fCompanyName");
                string nickName = GetFormValue("fNickName");
                string tel = GetFormValue("fTel");
                string fax = GetFormValue("fFax");
                string phone = GetFormValue("fPhone");
                string email = GetFormValue("fEmail");
                string address = GetFormValue("fAddress");
                string description = GetFormValue("fDescription");

                var entity = CompanyService.GetCompanyPro(SystemID, companyId);
                if (entity == null)
                    return Error("公司编号不存在！");
                string strNewEntity = GetNewEntityJson(entity, companyName, nickName, tel, fax, phone, email, address, description);

                long operationId = 0;
                TableOperationManager.Update(entity, strNewEntity, out operationId);
                var result = CompanyService.UpdateCompanyPro(SystemID, companyId, companyName, nickName, tel, fax, phone, email, address, description);
                TableOperationManager.SetState(operationId, result);
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
        #endregion

        #region 私有方法
        private string GetNewEntityJson(Institution_Company entity, string companyName, string nickName, string tel, string fax, string phone, string email, string address, string description)
        {
            try
            {
                Institution_Company m = new Institution_Company();
                m.SystemID = entity.SystemID;
                m.CompanyID = entity.CompanyID;
                m.DealerID = entity.DealerID;
                m.ClassID = entity.ClassID;
                m.UserName = entity.UserName;
                m.Password = entity.Password;
                m.CompanyName = companyName;
                m.LogoImages = entity.LogoImages;
                m.NickName = nickName;
                m.Tel = tel;
                m.Fax = fax;
                m.Phone = phone;
                m.Email = email;
                m.Address = address;
                m.Description = description;
                m.RegisterIpAddress = entity.RegisterIpAddress;
                m.RegisterTime = entity.RegisterTime;
                m.Version = entity.Version;
                m.StartTime = entity.StartTime;
                m.EndTime = entity.EndTime;
                m.LoginTotalNumber = entity.LoginTotalNumber;
                m.State = entity.State;
                m.IsDal = entity.IsDal;
                m.CreateDate = entity.CreateDate;
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