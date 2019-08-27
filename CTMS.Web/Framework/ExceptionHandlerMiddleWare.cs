using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CTMS.Web.Framework
{
    using CTMS.DbModels;
    using CTMS.Common.Net;
    using CTMS.Common.Logs;
    using CTMS.IService.Log;
    /// <summary>
    /// 全局异常捕捉跟踪中间件
    /// 
    /// 使用方法：Startup.cs
    ///           app.UseMiddleware(typeof(Framework.ExceptionHandlerMiddleWare));
    /// 
    /// </summary>
    public class ExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate Next;
        private readonly IErrorRecordService ErrorRecordService;
        public ExceptionHandlerMiddleWare(RequestDelegate Next, IErrorRecordService ErrorRecordService)
        {
            this.Next = Next;
            this.ErrorRecordService = ErrorRecordService;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception == null)
            {
                return;
            }
            await WriteExceptionAsync(context, exception).ConfigureAwait(false);
        }
        private async Task WriteExceptionAsync(HttpContext context, Exception exception)
        {
            //返回友好的提示 Agent
            HttpResponse response = context.Response;

            string ipAddress = Net.Ip;
            string scheme = response.HttpContext.Request.Scheme;
            string host = response.HttpContext.Request.Host.Value;
            string pathBase = response.HttpContext.Request.PathBase.Value;
            string path = response.HttpContext.Request.Path.Value;
            string queryString = response.HttpContext.Request.QueryString.Value;
            string url = string.Format("{0}://{1}{2}{3}{4}", scheme, host, pathBase, path, queryString);
            string message = exception.Message.Replace("\n", "");

            bool result = SaveErrorRecord(url, message, ipAddress);

            LogsManager.LogPath = string.Empty;
            LogsManager.WriteLog(LogsFile.Error, string.Format("--全局异常过滤器捕获的异常--开始------------"));
            LogsManager.WriteLog(LogsFile.Error, string.Format("系统编号：{0}", BaseSystemConfig.SystemID));
            LogsManager.WriteLog(LogsFile.Error, string.Format("访问网址：{0}", url));
            LogsManager.WriteLog(LogsFile.Error, string.Format("异常信息：{0}", message));
            LogsManager.WriteLog(LogsFile.Error, string.Format("IP地址：{0}", ipAddress));
            LogsManager.WriteLog(LogsFile.Error, string.Format("保存结果：{0}", result));
            LogsManager.WriteLog(LogsFile.Error, string.Format("--全局异常过滤器捕获的异常--结束------------"));
            
            var data = new
            {
                status = response.StatusCode,
                message = exception.Message,
            };
            response.Redirect("/home/error");
            response.ContentType = "application/json";
            await response.WriteAsync(JsonConvert.SerializeObject(data)).ConfigureAwait(false);
        }
        private bool SaveErrorRecord(string url, string message, string ipAddress)
        {
            try
            {
                return ErrorRecordService.SaveErrorRecord(new Log_ErrorRecord()
                {
                    SystemID = BaseSystemConfig.SystemID,
                    Url = url,
                    Message = message,
                    IpAddress = ipAddress,
                    State = true
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

}
