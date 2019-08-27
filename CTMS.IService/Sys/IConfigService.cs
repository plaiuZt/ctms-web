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
    public partial interface IConfigService:IBaseService<Sys_Config>
    {
        bool UpdateConfig(Sys_Config entity);
        Sys_Config GetConfig(int systemId, string companyId);

        bool UpdateConfigPro(Sys_Config entity);
        bool UpdateConfigShieldingPro(int systemId, string companyId,string shielding);
        Sys_Config GetConfigPro(int systemId, string companyId);

    }
}
