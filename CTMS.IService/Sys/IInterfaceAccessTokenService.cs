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
    public partial interface IInterfaceAccessTokenService:IBaseService<Sys_InterfaceAccessToken>
    {
        bool SaveInterfaceAccessTokenPro(string token, int systemId, string appId, int expiresIn, string ipAddress, int createTimestamp);
        bool SaveInterfaceAccessTokenAutoPro(string token, int systemId, string appId, string appSecret, int expiresIn, string ipAddress, int createTimestamp);
        SP_Get_Sys_InterfaceAccessToken GetInterfaceAccessTokenPro(string token);
        int GetInterfaceAccessTokenTotalNumberPro(int systemId, string appId);
        bool VerifyInterfaceAccessTokenPro(string token, int timestamp);


    }
}
