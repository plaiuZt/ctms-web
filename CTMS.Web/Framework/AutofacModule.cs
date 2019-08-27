using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTMS.Web
{
    using Autofac;
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.IService.Basics;
    using CTMS.IService.Extend;
    using CTMS.IService.Info;
    using CTMS.IService.Institution;
    using CTMS.IService.Log;
    using CTMS.IService.Member;
    using CTMS.IService.Service;
    using CTMS.IService.Sys;
    using CTMS.Web.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;

    public class AutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method in ConfigureServices.
            //builder.Register(c => new ValuesService(c.Resolve<ILogger<ValuesService>>())).As<IValuesService>().InstancePerLifetimeScope();
            builder.Register(c => new BaseManager(c.Resolve<IHttpContextAccessor>(), c.Resolve<IOperatorService>())).As<IBaseManager>().InstancePerLifetimeScope();
            builder.Register(c => new BaseApiManager(c.Resolve<IApiRecordManager>(), c.Resolve<IInterfaceAccountService>(), c.Resolve<IInterfaceAccessTokenService>(), c.Resolve<IAccountService>(), c.Resolve<IAccessTokenService>())).As<IBaseApiManager>().InstancePerLifetimeScope();
            builder.Register(c => new ApiRecordManager(c.Resolve<IHttpContextAccessor>(), c.Resolve<IInterfaceAccountService>(), c.Resolve<IInterfaceAccessTokenService>(), c.Resolve<IAccessTokenService>(), c.Resolve<IWebApiAccessRecordService>())).As<IApiRecordManager>().InstancePerLifetimeScope();

            #region 操作日志类注册容器 Manager
            //系统部分
            builder.Register(c => new TableOperationManager<Sys_AccessCorsHost>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Sys_AccessCorsHost>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Sys_Code>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Sys_Code>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Sys_Config>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Sys_Config>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Sys_Function>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Sys_Function>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Sys_InterfaceAccessToken>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Sys_InterfaceAccessToken>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Sys_InterfaceAccessWhiteList>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Sys_InterfaceAccessWhiteList>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Sys_InterfaceAccount>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Sys_InterfaceAccount>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Sys_Operator>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Sys_Operator>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Sys_OperatorRole>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Sys_OperatorRole>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Sys_Role>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Sys_Role>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Sys_RoleFunction>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Sys_RoleFunction>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Sys_Version>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Sys_Version>>().InstancePerLifetimeScope();

            //公司部分
            builder.Register(c => new TableOperationManager<Institution_Company>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Institution_Company>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Institution_Dealer>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Institution_Dealer>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Institution_Department>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Institution_Department>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Institution_Position>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Institution_Position>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Institution_Staff>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Institution_Staff>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Institution_Store>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Institution_Store>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Institution_Supplier>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Institution_Supplier>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Institution_Warehouse>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Institution_Warehouse>>().InstancePerLifetimeScope();


            //日志部分
            builder.Register(c => new TableOperationManager<Log_ErrorRecord>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Log_ErrorRecord>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Log_LoginRecord>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Log_LoginRecord>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Log_Table>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Log_Table>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Log_TableDetails>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Log_TableDetails>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Log_TableOperation>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Log_TableOperation>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Log_VisitorRecord>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Log_VisitorRecord>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Log_WebApiAccessRecord>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Log_WebApiAccessRecord>>().InstancePerLifetimeScope();

            //会员部分
            builder.Register(c => new TableOperationManager<Member_AccessToken>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Member_AccessToken>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Member_Account>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Member_Account>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Member_Address>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Member_Address>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Member_AmountRecord>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Member_AmountRecord>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Member_Invoice>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Member_Invoice>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Member_LoginLogs>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Member_LoginLogs>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Member_PointRecord>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Member_PointRecord>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Member_Rank>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Member_Rank>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Member_RefreshToken>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Member_RefreshToken>>().InstancePerLifetimeScope();

            //客服部分
            builder.Register(c => new TableOperationManager<Service_MessageBoard>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Service_MessageBoard>>().InstancePerLifetimeScope();

            //基础公共部分
            builder.Register(c => new TableOperationManager<Basics_Media>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Basics_Media>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Basics_MediaInterface>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Basics_MediaInterface>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Basics_MediaMember>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Basics_MediaMember>>().InstancePerLifetimeScope();

            //资讯部分
            builder.Register(c => new TableOperationManager<Info_Artice>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Info_Artice>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Info_Block>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Info_Block>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Info_Class>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Info_Class>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Info_Notice>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Info_Notice>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Info_NoticeCategory>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Info_NoticeCategory>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Info_Page>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Info_Page>>().InstancePerLifetimeScope();

            //扩展部分
            builder.Register(c => new TableOperationManager<Extend_Advertisement>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Extend_Advertisement>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Extend_AdvertisementDetails>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Extend_AdvertisementDetails>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Extend_Link>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Extend_Link>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Extend_LinkGroup>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Extend_LinkGroup>>().InstancePerLifetimeScope();
            builder.Register(c => new TableOperationManager<Extend_SearchKeyword>(c.Resolve<ITableService>(), c.Resolve<ITableDetailsService>(), c.Resolve<ITableOperationService>())).As<ITableOperationManager<Extend_SearchKeyword>>().InstancePerLifetimeScope();

            #endregion


            #region 正式注册容器 DAL
            builder.Register(c => new DAL.Sys.AccessCorsHostDAL(c.Resolve<CTMSContext>())).As<IDAL.Sys.IAccessCorsHostDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Sys.CodeDAL(c.Resolve<CTMSContext>())).As<IDAL.Sys.ICodeDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Sys.ConfigDAL(c.Resolve<CTMSContext>())).As<IDAL.Sys.IConfigDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Sys.FunctionDAL(c.Resolve<CTMSContext>())).As<IDAL.Sys.IFunctionDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Sys.RoleDAL(c.Resolve<CTMSContext>())).As<IDAL.Sys.IRoleDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Sys.OperatorDAL(c.Resolve<CTMSContext>())).As<IDAL.Sys.IOperatorDAL>().InstancePerLifetimeScope();

            builder.Register(c => new DAL.Sys.InterfaceAccountDAL(c.Resolve<CTMSContext>())).As<IDAL.Sys.IInterfaceAccountDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Sys.InterfaceAccessWhiteListDAL(c.Resolve<CTMSContext>())).As<IDAL.Sys.IInterfaceAccessWhiteListDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Sys.InterfaceAccessTokenDAL(c.Resolve<CTMSContext>())).As<IDAL.Sys.IInterfaceAccessTokenDAL>().InstancePerLifetimeScope();

            builder.Register(c => new DAL.Log.TableDAL(c.Resolve<CTMSContext>())).As<IDAL.Log.ITableDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Log.TableDetailsDAL(c.Resolve<CTMSContext>())).As<IDAL.Log.ITableDetailsDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Log.TableOperationDAL(c.Resolve<CTMSContext>())).As<IDAL.Log.ITableOperationDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Log.ErrorRecordDAL(c.Resolve<CTMSContext>())).As<IDAL.Log.IErrorRecordDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Log.LoginRecordDAL(c.Resolve<CTMSContext>())).As<IDAL.Log.ILoginRecordDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Log.VisitorRecordDAL(c.Resolve<CTMSContext>())).As<IDAL.Log.IVisitorRecordDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Log.WebApiAccessRecordDAL(c.Resolve<CTMSContext>())).As<IDAL.Log.IWebApiAccessRecordDAL>().InstancePerLifetimeScope();

            builder.Register(c => new DAL.Institution.CompanyDAL(c.Resolve<CTMSContext>())).As<IDAL.Institution.ICompanyDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Institution.DepartmentDAL(c.Resolve<CTMSContext>())).As<IDAL.Institution.IDepartmentDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Institution.PositionDAL(c.Resolve<CTMSContext>())).As<IDAL.Institution.IPositionDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Institution.StoreDAL(c.Resolve<CTMSContext>())).As<IDAL.Institution.IStoreDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Institution.StaffDAL(c.Resolve<CTMSContext>())).As<IDAL.Institution.IStaffDAL>().InstancePerLifetimeScope();

            builder.Register(c => new DAL.Member.RankDAL(c.Resolve<CTMSContext>())).As<IDAL.Member.IRankDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Member.AccountDAL(c.Resolve<CTMSContext>())).As<IDAL.Member.IAccountDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Member.AccessTokenDAL(c.Resolve<CTMSContext>())).As<IDAL.Member.IAccessTokenDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Member.LoginLogsDAL(c.Resolve<CTMSContext>())).As<IDAL.Member.ILoginLogsDAL>().InstancePerLifetimeScope();

            builder.Register(c => new DAL.Service.MessageBoardDAL(c.Resolve<CTMSContext>())).As<IDAL.Service.IMessageBoardDAL>().InstancePerLifetimeScope();

            builder.Register(c => new DAL.Basics.MediaDAL(c.Resolve<CTMSContext>())).As<IDAL.Basics.IMediaDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Basics.MediaInterfaceDAL(c.Resolve<CTMSContext>())).As<IDAL.Basics.IMediaInterfaceDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Basics.MediaMemberDAL(c.Resolve<CTMSContext>())).As<IDAL.Basics.IMediaMemberDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Basics.VMediaDAL(c.Resolve<CTMSContext>())).As<IDAL.Basics.IVMediaDAL>().InstancePerLifetimeScope();

            builder.Register(c => new DAL.Info.NoticeCategoryDAL(c.Resolve<CTMSContext>())).As<IDAL.Info.INoticeCategoryDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Info.NoticeDAL(c.Resolve<CTMSContext>())).As<IDAL.Info.INoticeDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Info.BlockDAL(c.Resolve<CTMSContext>())).As<IDAL.Info.IBlockDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Info.ClassDAL(c.Resolve<CTMSContext>())).As<IDAL.Info.IClassDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Info.PageDAL(c.Resolve<CTMSContext>())).As<IDAL.Info.IPageDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Info.ArticeDAL(c.Resolve<CTMSContext>())).As<IDAL.Info.IArticeDAL>().InstancePerLifetimeScope();

            builder.Register(c => new DAL.Extend.SearchKeywordDAL(c.Resolve<CTMSContext>())).As<IDAL.Extend.ISearchKeywordDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Extend.AdvertisementDAL(c.Resolve<CTMSContext>())).As<IDAL.Extend.IAdvertisementDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Extend.AdvertisementDetailsDAL(c.Resolve<CTMSContext>())).As<IDAL.Extend.IAdvertisementDetailsDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Extend.LinkDAL(c.Resolve<CTMSContext>())).As<IDAL.Extend.ILinkDAL>().InstancePerLifetimeScope();
            builder.Register(c => new DAL.Extend.LinkGroupDAL(c.Resolve<CTMSContext>())).As<IDAL.Extend.ILinkGroupDAL>().InstancePerLifetimeScope();

            #endregion


            #region 正式注册容器 BLL
            builder.Register(c => new Service.Sys.AccessCorsHostService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Sys.IAccessCorsHostDAL>())).As<IAccessCorsHostService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Sys.CodeService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Sys.ICodeDAL>())).As<ICodeService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Sys.ConfigService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Sys.IConfigDAL>())).As<IConfigService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Sys.FunctionService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Sys.IFunctionDAL>())).As<IFunctionService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Sys.RoleService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Sys.IRoleDAL>())).As<IRoleService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Sys.OperatorService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Sys.IOperatorDAL>())).As<IOperatorService>().InstancePerLifetimeScope();

            builder.Register(c => new Service.Sys.InterfaceAccountService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Sys.IInterfaceAccountDAL>())).As<IInterfaceAccountService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Sys.InterfaceAccessWhiteListService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Sys.IInterfaceAccessWhiteListDAL>())).As<IInterfaceAccessWhiteListService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Sys.InterfaceAccessTokenService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Sys.IInterfaceAccessTokenDAL>())).As<IInterfaceAccessTokenService>().InstancePerLifetimeScope();

            builder.Register(c => new Service.Log.TableService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Log.ITableDAL>())).As<ITableService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Log.TableDetailsService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Log.ITableDetailsDAL>())).As<ITableDetailsService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Log.TableOperationService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Log.ITableOperationDAL>())).As<ITableOperationService>().InstancePerLifetimeScope();

            
            builder.Register(c => new Service.Log.ErrorRecordService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Log.IErrorRecordDAL>())).As<IErrorRecordService>().InstancePerLifetimeScope();

            builder.Register(c => new Service.Log.LoginRecordService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Log.ILoginRecordDAL>())).As<ILoginRecordService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Log.VisitorRecordService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Log.IVisitorRecordDAL>())).As<IVisitorRecordService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Log.WebApiAccessRecordService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Log.IWebApiAccessRecordDAL>())).As<IWebApiAccessRecordService>().InstancePerLifetimeScope();

            builder.Register(c => new Service.Institution.CompanyService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Institution.ICompanyDAL>())).As<ICompanyService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Institution.DepartmentService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Institution.IDepartmentDAL>())).As<IDepartmentService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Institution.PositionService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Institution.IPositionDAL>())).As<IPositionService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Institution.StoreService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Institution.IStoreDAL>())).As<IStoreService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Institution.StaffService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Institution.IStaffDAL>())).As<IStaffService>().InstancePerLifetimeScope();

            builder.Register(c => new Service.Member.RankService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Member.IRankDAL>())).As<IRankService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Member.AccountService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Member.IAccountDAL>())).As<IAccountService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Member.AccessTokenService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Member.IAccessTokenDAL>())).As<IAccessTokenService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Member.LoginLogsService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Member.ILoginLogsDAL>())).As<ILoginLogsService>().InstancePerLifetimeScope();

            builder.Register(c => new Service.Service.MessageBoardService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Service.IMessageBoardDAL>())).As<IMessageBoardService>().InstancePerLifetimeScope();

            builder.Register(c => new Service.Basics.MediaService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Basics.IMediaDAL>())).As<IMediaService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Basics.MediaInterfaceService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Basics.IMediaInterfaceDAL>())).As<IMediaInterfaceService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Basics.MediaMemberService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Basics.IMediaMemberDAL>())).As<IMediaMemberService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Basics.VMediaService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Basics.IVMediaDAL>())).As<IVMediaService>().InstancePerLifetimeScope();

            builder.Register(c => new Service.Info.NoticeCategoryService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Info.INoticeCategoryDAL>())).As<INoticeCategoryService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Info.NoticeService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Info.INoticeDAL>())).As<INoticeService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Info.BlockService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Info.IBlockDAL>())).As<IBlockService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Info.ClassService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Info.IClassDAL>())).As<IClassService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Info.PageService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Info.IPageDAL>())).As<IPageService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Info.ArticeService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Info.IArticeDAL>())).As<IArticeService>().InstancePerLifetimeScope();


            builder.Register(c => new Service.Extend.SearchKeywordService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Extend.ISearchKeywordDAL>())).As<ISearchKeywordService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Extend.AdvertisementService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Extend.IAdvertisementDAL>())).As<IAdvertisementService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Extend.AdvertisementDetailsService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Extend.IAdvertisementDetailsDAL>())).As<IAdvertisementDetailsService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Extend.LinkService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Extend.ILinkDAL>())).As<ILinkService>().InstancePerLifetimeScope();
            builder.Register(c => new Service.Extend.LinkGroupService(c.Resolve<CTMSContext>(), c.Resolve<IDAL.Extend.ILinkGroupDAL>())).As<ILinkGroupService>().InstancePerLifetimeScope();

            #endregion


        }
    }
}
