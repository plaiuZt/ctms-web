using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Sys
{
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;

    public partial interface IRoleService
    {
        bool SaveRolePro(int systemId, string companyId, string roleId, string roleName, string functionId, string remark, bool state);
        bool UpdateRolePro(int systemId, string companyId, string roleId, string roleName, string functionId, string remark, bool state);
        bool UpdateRoleStatePro(int systemId, string companyId, string roleId, bool state);
        bool DeleteRolePro(int systemId, string companyId, string roleId);
        Sys_Role GetRolePro(int systemId, string companyId, string roleId);
        List<Sys_Role> GetRoleAllPro(int systemId, string companyId);
        List<SP_Get_Sys_RoleFunction> GetRoleFunctionPro(int systemId, string companyId, string roleId);
        List<SP_Get_Sys_RoleFunctionSelect> GetRoleFunctionSelectPro(int systemId, string companyId, string roleId);
        List<Sys_Role> GetRolePagingPro(int systemId, string companyId, int pageId, int pageSize, out int rowCount);
        List<Sys_Role> SearchRolePro(int systemId, string companyId, string startTime, string endTime, string keyword);

    }
}
