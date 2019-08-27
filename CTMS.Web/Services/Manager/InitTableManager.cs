using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace CTMS.Web.Services
{
    using CTMS.DbModels;
    using CTMS.IService.Log;
    using CTMS.Common.Security;
    /// <summary>
    /// 
    /// </summary>
    public class InitTableManager: IInitTableManager
    {
        private readonly ITableService TableService;
        private readonly ITableDetailsService TableDetailsService;
        public InitTableManager(ITableService TableService, ITableDetailsService TableDetailsService)
        {
            this.TableService = TableService;
            this.TableDetailsService = TableDetailsService;
        }

        public void CreateTable<T>(T t) where T : class
        {
            try
            {
                string tableID = PrimaryKeyHelper.MakePrimaryKey(PrimaryKeyHelper.PrimaryKeyType.Table, PrimaryKeyHelper.PrimaryKeyLen.V1);
                string tableName = typeof(T).Name;
                string primaryKey = "SystemID";
                string Account = "sys";
                string NickName = "系统生成";

                Log_Table entity = new Log_Table();
                entity.TableID = tableID;
                entity.TableName = tableName;
                entity.PrimaryKey = primaryKey;
                entity.Account = Account;
                entity.NickName = NickName;

                List<Log_TableDetails> lists = new List<Log_TableDetails>();
                PropertyInfo[] pi = typeof(T).GetProperties();
                foreach (PropertyInfo p in pi)
                {
                    string columnName = p.Name.ToString();  //得到属性的名称
                    Type columnType = p.PropertyType;       //得到属性的类型
                    if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        columnType = p.PropertyType.GetGenericArguments()[0];
                    }
                    lists.Add(new Log_TableDetails()
                    {
                        TableID = tableID,
                        TableName = tableName,
                        ColumnName = columnName,
                        ColumnDataType = columnType.Name,
                        Account = Account,
                        NickName = NickName,
                    });
                }
                TableService.SaveTable(entity);
                TableDetailsService.SaveTableDetails(lists);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteTableAll()
        {
            try
            {
                TableService.DeleteTable();
                TableDetailsService.DeleteTableDetails();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Init()
        {
            try
            {
                //清空表
                //DeleteTableAll();

                CreateTable(new Sys_AccessCorsHost());
                CreateTable(new Sys_Code());
                CreateTable(new Sys_Config());
                CreateTable(new Sys_Function());
                CreateTable(new Sys_InterfaceAccessToken());
                CreateTable(new Sys_InterfaceAccessWhiteList());
                CreateTable(new Sys_InterfaceAccount());
                CreateTable(new Sys_Operator());
                CreateTable(new Sys_OperatorRole());
                CreateTable(new Sys_Role());
                CreateTable(new Sys_RoleFunction());
                CreateTable(new Sys_Version());

                CreateTable(new Log_ErrorRecord());
                CreateTable(new Log_LoginRecord());
                CreateTable(new Log_Table());
                CreateTable(new Log_TableDetails());
                CreateTable(new Log_TableOperation());
                CreateTable(new Log_VisitorRecord());
                CreateTable(new Log_WebApiAccessRecord());

                CreateTable(new Institution_Company());
                CreateTable(new Institution_Dealer());
                CreateTable(new Institution_Department());
                CreateTable(new Institution_Position());
                CreateTable(new Institution_Staff());
                CreateTable(new Institution_Store());
                CreateTable(new Institution_Supplier());
                CreateTable(new Institution_Warehouse());

                CreateTable(new Member_AccessToken());
                CreateTable(new Member_Account());
                CreateTable(new Member_Address());
                CreateTable(new Member_Invoice());
                CreateTable(new Member_LoginLogs());
                CreateTable(new Member_AmountRecord());
                CreateTable(new Member_PointRecord());
                CreateTable(new Member_Rank());
                CreateTable(new Member_RefreshToken());

                CreateTable(new Basics_Media());
                CreateTable(new Basics_MediaInterface());
                CreateTable(new Basics_MediaMember());

                CreateTable(new Extend_Advertisement());
                CreateTable(new Extend_AdvertisementDetails());
                CreateTable(new Extend_Link());
                CreateTable(new Extend_LinkGroup());
                CreateTable(new Extend_SearchKeyword());

                CreateTable(new Info_Artice());
                CreateTable(new Info_Block());
                CreateTable(new Info_Class());
                CreateTable(new Info_Notice());
                CreateTable(new Info_NoticeCategory());
                CreateTable(new Info_Page());

                CreateTable(new Service_MessageBoard());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
