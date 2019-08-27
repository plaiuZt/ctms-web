using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;

namespace CTMS.Web.Controllers
{
    using CTMS.IService.Sys;
    using CTMS.Web.Models;
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        private readonly SiteConfig SiteConfig;
        private readonly IConfigService ConfigService;
        public HomeController(IOptions<SiteConfig> SiteConfig, IConfigService ConfigService)
        {
            this.SiteConfig = SiteConfig.Value;
            this.ConfigService = ConfigService;
        }
        public IActionResult Index()
        {
            try
            {
                int systemId = BaseSystemConfig.SystemID;
                string companyId = SiteConfig.CompanyID;
                var entity = ConfigService.GetConfig(systemId, companyId);
                string homeUrl =string.IsNullOrEmpty(entity.HomeUrl)? SiteConfig.HomeUrl : entity.HomeUrl;
                return Redirect(homeUrl);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IActionResult Error()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

 



}
