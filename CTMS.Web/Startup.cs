using System;
using System.Linq;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace CTMS.Web
{
    using Autofac;
    using CTMS.Common.Extension;
    using CTMS.Plugins.UEditor;
    using CTMS.Common.Json;
    using CTMS.DbModels;
    using CTMS.DbContexts;
    using CTMS.Model;
    using FreeSql;
    using System.Diagnostics;

    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        public static IFreeSql Fsql;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            try
            {
                
                Fsql = new FreeSql.FreeSqlBuilder()
                    .UseConnectionString(FreeSql.DataType.SqlServer, Configuration.GetConnectionString("SqlServerConnection"))
                    .UseAutoSyncStructure(false)
                    .UseNoneCommandParameter(true)
                    .UseMonitorCommand(
                        cmd =>
                        {
                            Trace.WriteLine(cmd.CommandText);
                        }, //监听SQL命令对象，在执行前
                        (cmd, traceLog) =>
                        {
                            Console.WriteLine(traceLog);
                        }) //监听SQL命令对象，在执行后
                    .Build();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IConfiguration Configuration { get; }
        public IHttpContextAccessor HttpContextAccessor { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //配置 Session、Cookies、Cache
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromSeconds(7200);
            });
            //配置数据库链接DI
            //services.AddDbContext<CTMSContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));
            //services.AddEntityFrameworkSqlServer().AddDbContext<CTMSContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection"));
            //}, ServiceLifetime.Scoped);
            services.AddSingleton(Fsql);
            services.AddFreeDbContext<CTMSContext>(options => options.UseFreeSql(Fsql));
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.Configure<Models.SiteConfig>(Configuration.GetSection("SiteConfig"));


            //配置读写配置文件
            services.AddSingleton(Configuration);
            //配置http body
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //配置上传文件大小，系统默信最大20M
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 20971520; //最大长度100M
            });

            //百度在线编辑器UEditor 配置
            services.AddUEditorService("appsettings.UEditorConfig.json", false);

            //跨域请求 API
            //.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().AllowCredentials()
            //var urls = GetAppCors(Configuration["AppCors:Url"].Split(","));
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSameDomain", builder => builder.WithOrigins(urls));
            //});

            //系统默认MVC配置
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //API版本控制DI
            services.AddApiVersioning(options =>
            {
                options.ApiVersionReader = new MediaTypeApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseStaticHttpContext();

            //异常处理中间件
            app.UseMiddleware(typeof(Framework.ExceptionHandlerMiddleWare));

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        /// <summary>
        /// Autofac容器注册
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModule());
        }
        /// <summary>
        /// 获取跨域URL列表
        /// </summary>
        /// <param name="urls"></param>
        /// <returns></returns>
        public string[] GetAppCors(string[] urls)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                int systemId = BaseSystemConfig.SystemID;

                CTMSContext dbContent = new CTMSContext();
                var result = dbContent.SP_Get_Sys_AccessCorsHostAll(systemId, out errCode, out errMsg);
                if (result == null)
                {
                    return urls;
                }
                else
                {
                    var lists = result.ToObject<List<Sys_AccessCorsHost>>();
                    int count = lists.Count();
                    string[] arrayUrl = new string[count];
                    for (var i = 0; i < count; i++)
                    {
                        arrayUrl[i] = lists[i].WebHost;
                    }
                    return arrayUrl;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
