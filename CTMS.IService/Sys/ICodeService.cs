using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Sys
{
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;

    /// <summary>
    /// 系统编号业务逻辑服务类
    /// </summary>
    public partial interface ICodeService:IBaseService<Sys_Code>
    {
        bool SaveCodePro(int systemId, string systemName, string description, bool state);
        bool DeleteCodePro(int systemId);
        bool UpdateCodePro(int systemId, string systemName, string description, bool state);
        bool UpdateCodeStatePro(int systemId, bool state);
        Sys_Code GetCodePro(int systemId);
        List<Sys_Code> GetCodeAllPro();

    }
}
