﻿using System;
using System.Web;
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
    using CTMS.Web.Services;
    using CTMS.IService.Log;
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("2.0")]
    [EnableCors("AllowSameDomain")]
    [ControllerName("log/visitor/record")]
    public class LogVisitorRecordController : BaseApiController
    {
        private readonly IBaseApiManager BaseApiManager;
        private readonly IVisitorRecordService VisitorRecordService;
        public LogVisitorRecordController(IBaseApiManager BaseApiManager, IVisitorRecordService VisitorRecordService) : base(BaseApiManager)
        {
            this.BaseApiManager = BaseApiManager;
            this.VisitorRecordService = VisitorRecordService;
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
                if (!IsUuid(uuid))
                    return Error(logId, "verify uuid fail！");
                bool isParams = IsSaveParams(fromValue);
                var entityInterfaceAccount = GetInterfaceAccountByUuid(uuid);
                string companyId = entityInterfaceAccount.CompanyID;
                string ipAddress = Net.Ip;
                string host = GetJObjectValue(fromValue, "host");
                string absoluteUri = GetJObjectValue(fromValue, "absolute_uri");
                string queryString = GetJObjectValue(fromValue, "query_string");
                var entity = new Log_VisitorRecord()
                {
                    SystemID = SystemID,
                    CompanyID = companyId,
                    ClientID = 1,
                    IpAddress = ipAddress,
                    Host = host,
                    AbsoluteUri = absoluteUri,
                    QueryString = HttpUtility.UrlDecode(queryString)
                };
                var result = VisitorRecordService.SaveVisitorRecord(entity);
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

        #region 私有化方汉
        private bool IsSaveParams(JObject formValue)
        {
            try
            {
                if (formValue == null)
                    throw new Exception("params not empty！");
                if (formValue.Property("host") == null)
                    throw new Exception("lack host params！");
                if (formValue.Property("absolute_uri") == null)
                    throw new Exception("lack absolute_uri params！");
                if (formValue.Property("query_string") == null)
                    throw new Exception("lack query_string params！");
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