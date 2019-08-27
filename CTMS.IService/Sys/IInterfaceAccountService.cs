using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Sys
{
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;

    /// <summary>
    /// 
    /// </summary>
    public partial interface IInterfaceAccountService:IBaseService<Sys_InterfaceAccount>
    {
        bool SaveInterfaceAccountPro(int systemId, string companyId, string account, string password, bool isWcf, bool isWeb, bool isApi, bool isCors, string description, bool state);
        bool DeleteInterfaceAccountPro(int systemId, string companyId, string account);
        bool UpdateInterfaceAccountPro(int systemId, string companyId, string account, string password, bool isWcf, bool isWeb, bool isApi, bool isCors, string description, bool state);
        bool UpdateInterfaceAccountAppKeyPro(int systemId, string companyId, string account);
        bool UpdateInterfaceAccountAppSecretPro(int systemId, string companyId, string account);
        bool UpdateInterfaceAccountDelPro(int systemId, string companyId, string account, bool isDel);
        bool UpdateInterfaceAccountPasswordPro(int systemId, string companyId, string account, string password);
        bool UpdateInterfaceAccountStatePro(int systemId, string companyId, string account, bool state);
        Sys_InterfaceAccount GetInterfaceAccountPro(int systemId, string companyId, string account);
        Sys_InterfaceAccount GetInterfaceAccountByAppIDPro(int systemId, string appId);
        Sys_InterfaceAccount GetInterfaceAccountByUuidPro(int systemId, string uuid);
        Sys_InterfaceAccount GetInterfaceAccountByTokenPro(int systemId, string token);
        List<Sys_InterfaceAccount> GetInterfaceAccountAllPro(int systemId, string companyId);
        List<Sys_InterfaceAccount> GetInterfaceAccountPagingPro(int systemId, string companyId, int pageId, int pageSize, out int rowCount);
        List<Sys_InterfaceAccount> SearchInterfaceAccountPro(int systemId, string companyId, string startTime, string endTime, string keyword);

        bool VerifyInterfaceAccountPro(int systemId, string companyId, string account, string password, int classId);
        bool VerifyInterfaceAccountByAppIDPro(int systemId, string appId, string appSecret);
        bool VerifyInterfaceAccountByUuIDPro(int systemId, string uuid);
    }
}
