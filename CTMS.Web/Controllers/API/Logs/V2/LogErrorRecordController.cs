using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CTMS.Web.Controllers.API.Logs.V2
{
    using CTMS.DbModels;
    using CTMS.Common.Net;
    using CTMS.IService.Log;
    using CTMS.Common.Extension;
    using CTMS.Web.Services;
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("2.0")]
    [EnableCors("AllowSameDomain")]
    [ControllerName("log/error/record")]
    public class LogErrorRecordController : BaseApiController
    {
        private readonly IBaseApiManager BaseApiManager;
        private readonly IErrorRecordService ErrorRecordService;
        public LogErrorRecordController(IBaseApiManager BaseApiManager, IErrorRecordService ErrorRecordService) : base(BaseApiManager)
        {
            this.BaseApiManager = BaseApiManager;
            this.ErrorRecordService = ErrorRecordService;
        }

        [HttpGet]
        [ActionName("index")]
        public IActionResult Index(string uuid)
        {
            try
            {
                string index = "index";
                var data = new { index, uuid };
                return Success("ok", data);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        [HttpPost]
        [ActionName("save")]
        public IActionResult Save(string uuid, [FromBody]JObject fromValue)
        {
            long logId = 0;
            try
            {
                logId = BaseApiManager.SaveLogs(uuid, fromValue);
                if (!IsUuid(uuid)) { return Error(logId, "verify uuid fail！"); }
                bool isParams = IsSaveParams(fromValue);
                var entityInterfaceAccount = GetInterfaceAccountByUuid(uuid);
                string companyId = entityInterfaceAccount.CompanyID;
                
                string clientId = GetJObjectValue(fromValue, "client_id");
                string url = GetJObjectValue(fromValue, "url");
                string message = GetJObjectValue(fromValue, "message");
                string ipAddress = Net.Ip;
                var entity = new Log_ErrorRecord()
                {
                    SystemID = SystemID,
                    ClientID = clientId.ToInt().ToByte(),
                    Url = url,
                    Message = message,
                    IpAddress = ipAddress,
                    State = true
                };
                var result = ErrorRecordService.SaveErrorRecord(entity);
                if (result)
                    return Success(logId, "ok");
                else
                    return Error(logId, "fail");
            }
            catch (Exception ex)
            {
                return Error(logId, ex.Message);
            }
        }

        #region 私有化方法
        private bool IsSaveParams(JObject formValue)
        {
            try
            {
                if (formValue == null)
                    throw new Exception("params not empty！");
                if (formValue.Property("client_id") == null)
                    throw new Exception("lack client_id params！");
                if (formValue.Property("url") == null)
                    throw new Exception("lack url params！");
                if (formValue.Property("message") == null)
                    throw new Exception("lack message params！");
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }

}