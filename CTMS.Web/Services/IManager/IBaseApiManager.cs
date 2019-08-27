using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTMS.Web.Services
{
    using CTMS.DbModels;
    /// <summary>
    /// 
    /// </summary>
    public partial interface IBaseApiManager
    {
        long SaveLogs(string appId);
        long SaveLogs(string appId, string parameter);
        long SaveLogs(string token, object formValue);
        bool UpdateLogs(long id, string result, bool state);
        bool IsUuid(string uuid);
        bool IsToken(string token);
        bool IsAccessToken(string accessToken);
        Sys_InterfaceAccount GetInterfaceAccount(string companyId, string account);
        Sys_InterfaceAccount GetInterfaceAccountByToken(string token);
        Sys_InterfaceAccount GetInterfaceAccountByUuid(string uuid);
        Sys_InterfaceAccount GetInterfaceAccountByAppID(string appid);
        Member_Account GetMemberAccount(string companyId, string memberId);
        Member_Account GetMemberAccountByAccessToken(string accessToken);
        Member_Account GetMemberAccountByRefreshToken(string refreshToken);


    }
}
