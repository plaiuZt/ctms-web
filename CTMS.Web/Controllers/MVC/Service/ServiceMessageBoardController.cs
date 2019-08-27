using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CTMS.Web.Controllers.MVC.Service
{
    using CTMS.DbModels;
    using CTMS.IService.Service;
    using CTMS.Common.Extension;
    using CTMS.Web.Models;
    using CTMS.Web.Services;
    using CTMS.Common.Json;

    /// <summary>
    /// 
    /// </summary>
    [AdminAuthorize(Roles = "Admins")]
    public class ServiceMessageBoardController : BaseController
    {
        private readonly IBaseManager BaseManager;
        private readonly IMessageBoardService MessageBoardService;
        private readonly ITableOperationManager<Service_MessageBoard> TableOperationManager;
        public ServiceMessageBoardController(IBaseManager BaseManager, IMessageBoardService MessageBoardService, ITableOperationManager<Service_MessageBoard> TableOperationManager) : base(BaseManager)
        {
            this.BaseManager = BaseManager;
            this.MessageBoardService = MessageBoardService;
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
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.客服管理.留言管理.列表);
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
                List<Service_MessageBoard> lists = new List<Service_MessageBoard>();
                string strKeyword = string.Format("{0}{1}{2}", startTime, state, keyword);
                if (string.IsNullOrWhiteSpace(strKeyword))
                    lists = MessageBoardService.GetMessageBoardTop(SystemID, CompanyID, total);
                else
                    lists = MessageBoardService.SearchMessageBoard(SystemID, CompanyID, startTime, endTime, state, keyword, total);
                ViewData["Count"] = MessageBoardService.CountMessageBoard(SystemID, CompanyID);
                return View(lists);
            }
            catch (Exception ex)
            {
                return ToError(ex.Message);
            }
        }
        public IActionResult Show(string messageId)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.客服管理.留言管理.查看);
                if (!IsPermission(funcId)) { return ToPermission(funcId); }
                var entity = MessageBoardService.GetMessageBoard(SystemID, CompanyID, messageId);
                if (entity == null)
                    return ToError("message id invalid！");
                return View(entity);
            }
            catch (Exception ex)
            {
                return ToError(ex.Message);
            }
        }
        public IActionResult Reply(string messageId)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.客服管理.留言管理.回复);
                if (!IsPermission(funcId)) { return ToPermission(funcId); }
                var entity = MessageBoardService.GetMessageBoard(SystemID, CompanyID, messageId);
                if (entity == null)
                    return ToError("message id invalid！");
                return View(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region 操作方法
        [HttpPost]
        public JsonResult UpdateState(string messageId, bool state)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.客服管理.留言管理.审阅);
                if (!IsPermission(funcId)) { return Error("您没有操作权限，请联系系统管理员！"); }

                var entity = MessageBoardService.GetMessageBoard(SystemID, CompanyID, messageId);
                var oldEntity = GetOldEntity(entity);
                var result = MessageBoardService.UpdateMessageBoardState(SystemID, CompanyID, messageId, state);
                TableOperationManager.Update(oldEntity, entity.ToJson(), result);
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
        public JsonResult UpdateReply(string messageId)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.客服管理.留言管理.回复);
                if (!IsPermission(funcId)) { return Error("您没有操作权限，请联系系统管理员！"); }

                string fReply = GetFormValue("fReply");
                string fState = GetFormValue("fState");
                bool state = fState.ToBool();

                var entity = MessageBoardService.GetMessageBoard(SystemID, CompanyID, messageId);
                var oldEntity = GetOldEntity(entity);
                var result = MessageBoardService.UpdateMessageBoardReply(SystemID, CompanyID, messageId, fReply, StaffID, StaffName, state);
                TableOperationManager.Update(oldEntity, entity.ToJson(), result);
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
        public JsonResult Delete(string messageId)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.客服管理.留言管理.删除);
                if (!IsPermission(funcId)) { return Error("您没有操作权限，请联系系统管理员！"); }
                var entity = MessageBoardService.GetMessageBoard(SystemID, CompanyID, messageId);
                var result = MessageBoardService.DeleteMessageBoard(SystemID, CompanyID, messageId);
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
        public JsonResult DeleteBatch(string[] arrId, string delete)
        {
            try
            {
                string funcId = PermissionEnum.CodeFormat((int)PermissionEnum.客服管理.留言管理.删除);
                if (!IsPermission(funcId)) { return Error("您没有操作权限，请联系系统管理员！"); }

                if (arrId.Length == 0)
                    return Error("请选择删除ID!");
                List<object> lists = new List<object>();
                foreach (var item in arrId)
                {
                    string messageId = item;
                    try
                    {
                        var entity = MessageBoardService.GetMessageBoard(SystemID, CompanyID, messageId);
                        bool result = MessageBoardService.DeleteMessageBoard(SystemID, CompanyID, messageId);
                        TableOperationManager.Delete(entity, result);
                        lists.Add(new { message_id = messageId, result, message = "ok" });
                    }
                    catch (Exception ex)
                    {
                        lists.Add(new { message_id = messageId, result = false, message = ex.Message });
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

        #region 私有方法
        private Service_MessageBoard GetOldEntity(Service_MessageBoard entity)
        {
            try
            {
                return entity.ToJson().ToObject<Service_MessageBoard>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}