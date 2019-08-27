using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CTMS.Web.Controllers.MVC.Member
{
    using CTMS.DbModels;
    using CTMS.IService.Member;
    using CTMS.Common.Extension;
    using CTMS.Web.Models;
    using CTMS.Web.Services;
    using CTMS.Common.Json;
    /// <summary>
    /// 会员等级控制器
    /// </summary>
    [AdminAuthorize(Roles = "Admins")]
    public class MemberRankController : BaseController
    {
        private readonly IBaseManager BaseManager;
        private readonly IRankService RankService;
        private readonly ITableOperationManager<Member_Rank> TableOperationManager;
        public MemberRankController(IBaseManager BaseManager, IRankService RankService, ITableOperationManager<Member_Rank> TableOperationManager) : base(BaseManager)
        {
            this.BaseManager = BaseManager;
            this.RankService = RankService;
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
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.会员管理.等级管理.列表);
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
                List<Member_Rank> lists = new List<Member_Rank>();
                string strKeyword = string.Format("", startTime, keyword);
                if (string.IsNullOrWhiteSpace(strKeyword))
                    lists = RankService.GetRankPagingPro(SystemID, CompanyID, pageId, pageSize, out rowCount);
                else
                    lists = RankService.SearchRankPro(SystemID, CompanyID, startTime, endTime, keyword);
                int totalNum = rowCount > 0 ? rowCount : lists == null ? 0 : lists.Count();
                ViewBag.Count = totalNum;
                return View(lists);
            }
            catch (Exception ex)
            {
                return ToError(ex.Message);
            }
        }
        public IActionResult Add(string rankId = "")
        {
            try
            {
                string funcId = "";
                if (!IsAddPermission(rankId, out funcId))
                    return ToPermission(funcId);
                if (string.IsNullOrWhiteSpace(rankId))
                    return View(new Member_Rank());
                var entity = RankService.GetRankPro(SystemID, CompanyID, rankId);
                if (entity == null)
                    return View(new Member_Rank());
                return View(entity);
            }
            catch (Exception ex)
            {
                return ToError(ex.Message);
            }
        }

        #region 操作方法
        [HttpPost]
        public JsonResult Save(string rankId)
        {
            try
            {
                if (!IsSavePermission(rankId))
                    return Error("您没有操作权限，请联系系统管理员！");

                string fRankName = GetFormValue("fRankName");
                string fMaxPoints = GetFormValue("fMaxPoints");
                string fDiscount = GetFormValue("fDiscount");
                string fRemark = GetFormValue("fRemark");
                string fState = GetFormValue("fState");

                int maxPoints = fMaxPoints.ToInt();
                int discount = fDiscount.ToInt();
                int showPrice = discount;
                bool state = fState.ToBool();

                if (maxPoints <= 0)
                    return Error("升级积分必须大于0");

                if (discount <= 0 || discount > 100)
                    return Error("优惠拆扣必须是1-100之间");


                bool result = false;
                if (string.IsNullOrEmpty(rankId))
                {
                    result = RankService.SaveRankPro(SystemID, CompanyID, fRankName, maxPoints, discount, showPrice, fRemark, state);
                    var entity = RankService.GetRankByMaxPointsPro(SystemID, CompanyID, maxPoints);
                    TableOperationManager.Add(entity, result);
                }
                else
                {
                    var entity = RankService.GetRankPro(SystemID, CompanyID, rankId);
                    result = RankService.UpdateRankPro(SystemID, CompanyID, rankId, fRankName, maxPoints, discount, showPrice, fRemark, state);
                    string newEntityJson = GetNewEntityJson(entity, fRankName, maxPoints, discount, showPrice, fRemark, state);
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
        public JsonResult UpdateState(string rankId, bool state)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.会员管理.等级管理.审核);
                if (!IsPermission(funcId)) { return Error("您没有操作权限，请联系系统管理员！"); }
                    
                var entity = RankService.GetRankPro(SystemID, CompanyID, rankId);
                var result = RankService.UpdateRankStatePro(SystemID, CompanyID, rankId, state);
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
        public JsonResult Delete(string rankId)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.会员管理.等级管理.删除);
                if (!IsPermission(funcId))
                    return Error("您没有操作权限，请联系系统管理员！");
                var entity = RankService.GetRankPro(SystemID, CompanyID, rankId);
                var result = RankService.DeleteRankPro(SystemID, CompanyID, rankId);
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
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.会员管理.等级管理.删除);
                if (!IsPermission(funcId))
                    return Error("您没有操作权限，请联系系统管理员！");
                if (arrId.Length == 0)
                    return Error("请选择删除ID!");
                List<object> lists = new List<object>();
                foreach (var item in arrId)
                {
                    string rankId = item;
                    try
                    {
                        var entity = RankService.GetRankPro(SystemID, CompanyID, rankId);
                        bool result = RankService.DeleteRankPro(SystemID, CompanyID, rankId);
                        TableOperationManager.Delete(entity, result);
                        lists.Add(new { rank_id = rankId, result, message = "ok" });
                    }
                    catch (Exception ex)
                    {
                        lists.Add(new { rank_id = rankId, result = false, message = ex.Message });
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
        public bool IsSavePermission(string rankId)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(rankId))
                {
                    string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.会员管理.等级管理.新增);
                    return IsPermission(funcId) ? true : false;
                }
                else
                {
                    string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.会员管理.等级管理.编辑);
                    return IsPermission(funcId) ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool IsAddPermission(string rankId, out string funcId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(rankId))
                {
                    funcId = PermissionEnum.CodeFormat((int)PermissionEnum.会员管理.等级管理.新增);
                    return IsPermission(funcId) ? true : false;
                }
                else
                {
                    funcId = PermissionEnum.CodeFormat((int)PermissionEnum.会员管理.等级管理.编辑);
                    return IsPermission(funcId) ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private string GetNewEntityJson(Member_Rank entity, bool state)
        {
            try
            {
                Member_Rank m = entity.ToJson().ToObject<Member_Rank>();
                m.State = state;
                return m.ToJson();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private string GetNewEntityJson(Member_Rank entity, string rankName, int maxPoints, int discount, int showPrice, string remark, bool state)
        {
            try
            {
                Member_Rank m = entity.ToJson().ToObject<Member_Rank>();
                m.RankName = rankName;
                m.MaxPoints = maxPoints;
                m.Discount = discount;
                m.ShowPrice = showPrice;
                m.Remark = remark;
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