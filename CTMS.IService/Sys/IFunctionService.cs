using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Sys
{
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;

    public partial interface IFunctionService:IBaseService<Sys_Function>
    {
        bool SaveFunctionPro(string functionId, string functionName, string parentId, int rankId, bool state);
        bool UpdateFunctionPro(string functionId, string functionName, bool state);
        bool UpdateFunctionStatePro(string functionId, bool state);
        bool DeleteFunctionPro(string functionId);
        Sys_Function GetFunctionPro(string functionId);
        List<Sys_Function> GetFunctionByParentIdPro(string parentId);
    }
}
