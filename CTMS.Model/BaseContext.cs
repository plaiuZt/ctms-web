using CTMS.DbModels;
using FreeSql;
using System;
using System.Diagnostics;

namespace CTMS.Model
{
    public partial class BaseContext : DbContext
    {
        public BaseContext() { }
        public BaseContext(DbContextOptions options)
        {
            //开启一对多，级联保存功能
            Orm.SetDbContextOptions(x=>x.EnableAddOrUpdateNavigateList = true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //builder.UseFreeSql(CTMS.Web.Startup.Fsql);
        }

        #region DbSet
        public virtual DbSet<Basics_Media> Basics_Media { get; set; }
        public virtual DbSet<Basics_MediaInterface> Basics_MediaInterface { get; set; }
        public virtual DbSet<Basics_MediaMember> Basics_MediaMember { get; set; }
        public virtual DbSet<Extend_Advertisement> Extend_Advertisement { get; set; }
        public virtual DbSet<Extend_AdvertisementDetails> Extend_AdvertisementDetails { get; set; }
        public virtual DbSet<Extend_Link> Extend_Link { get; set; }
        public virtual DbSet<Extend_LinkGroup> Extend_LinkGroup { get; set; }
        public virtual DbSet<Extend_SearchKeyword> Extend_SearchKeyword { get; set; }
        public virtual DbSet<Info_Artice> Info_Artice { get; set; }
        public virtual DbSet<Info_Block> Info_Block { get; set; }
        public virtual DbSet<Info_Class> Info_Class { get; set; }
        public virtual DbSet<Info_Notice> Info_Notice { get; set; }
        public virtual DbSet<Info_NoticeCategory> Info_NoticeCategory { get; set; }
        public virtual DbSet<Info_Page> Info_Page { get; set; }
        public virtual DbSet<Institution_Company> Institution_Company { get; set; }
        public virtual DbSet<Institution_Dealer> Institution_Dealer { get; set; }
        public virtual DbSet<Institution_Department> Institution_Department { get; set; }
        public virtual DbSet<Institution_Position> Institution_Position { get; set; }
        public virtual DbSet<Institution_Staff> Institution_Staff { get; set; }
        public virtual DbSet<Institution_Store> Institution_Store { get; set; }
        public virtual DbSet<Institution_Supplier> Institution_Supplier { get; set; }
        public virtual DbSet<Institution_Warehouse> Institution_Warehouse { get; set; }
        public virtual DbSet<Log_ErrorRecord> Log_ErrorRecord { get; set; }
        public virtual DbSet<Log_LoginRecord> Log_LoginRecord { get; set; }
        public virtual DbSet<Log_Table> Log_Table { get; set; }
        public virtual DbSet<Log_TableDetails> Log_TableDetails { get; set; }
        public virtual DbSet<Log_TableOperation> Log_TableOperation { get; set; }
        public virtual DbSet<Log_VisitorRecord> Log_VisitorRecord { get; set; }
        public virtual DbSet<Log_WebApiAccessRecord> Log_WebApiAccessRecord { get; set; }
        public virtual DbSet<Member_AccessToken> Member_AccessToken { get; set; }
        public virtual DbSet<Member_Account> Member_Account { get; set; }
        public virtual DbSet<Member_Address> Member_Address { get; set; }
        public virtual DbSet<Member_AmountRecord> Member_AmountRecord { get; set; }
        public virtual DbSet<Member_Invoice> Member_Invoice { get; set; }
        public virtual DbSet<Member_LoginLogs> Member_LoginLogs { get; set; }
        public virtual DbSet<Member_PointRecord> Member_PointRecord { get; set; }
        public virtual DbSet<Member_Rank> Member_Rank { get; set; }
        public virtual DbSet<Member_RefreshToken> Member_RefreshToken { get; set; }
        public virtual DbSet<Service_MessageBoard> Service_MessageBoard { get; set; }
        public virtual DbSet<Sys_AccessCorsHost> Sys_AccessCorsHost { get; set; }
        public virtual DbSet<Sys_Code> Sys_Code { get; set; }
        public virtual DbSet<Sys_Config> Sys_Config { get; set; }
        public virtual DbSet<Sys_Function> Sys_Function { get; set; }
        public virtual DbSet<Sys_InterfaceAccessToken> Sys_InterfaceAccessToken { get; set; }
        public virtual DbSet<Sys_InterfaceAccessWhiteList> Sys_InterfaceAccessWhiteList { get; set; }
        public virtual DbSet<Sys_InterfaceAccount> Sys_InterfaceAccount { get; set; }
        public virtual DbSet<Sys_Operator> Sys_Operator { get; set; }
        public virtual DbSet<Sys_OperatorRole> Sys_OperatorRole { get; set; }
        public virtual DbSet<Sys_Role> Sys_Role { get; set; }
        public virtual DbSet<Sys_RoleFunction> Sys_RoleFunction { get; set; }
        public virtual DbSet<Sys_Version> Sys_Version { get; set; }

        #endregion
    }
}
