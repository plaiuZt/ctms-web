using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Sys
{
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    public partial interface IAccessCorsHostService:IBaseService<Sys_AccessCorsHost>
    {
        bool SaveAccessCorsHostPro(int systemId, string webHost, string remark, string account, string nickname, bool state);
        bool UpdateAccessCorsHostPro(int systemId, string webHost, string remark, bool state);
        bool DeleteAccessCorsHostPro(int systemId, string webHost);
        Sys_AccessCorsHost GetAccessCorsHostPro(int systemId, string webHost);
        List<Sys_AccessCorsHost> GetAccessCorsHostAllPro(int systemId);

    }
}
