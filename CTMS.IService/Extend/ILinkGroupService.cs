using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Extend
{
    using CTMS.DbModels;
    public partial interface ILinkGroupService:IBaseService<Extend_LinkGroup>
    {
        bool SaveLinkGroup(Extend_LinkGroup entity);
        bool UpdateLinkGroup(Extend_LinkGroup entity);
        bool UpdateLinkGroupState(int systemId, string companyId, string groupId, bool state);
        bool UpdateLinkGroupSort(int systemId, string companyId, string groupId, int sort);
        bool DeleteLinkGroup(int systemId, string companyId, string groupId);
        Extend_LinkGroup GetLinkGroup(int systemId, string companyId, string groupId);
        List<Extend_LinkGroup> GetLinkGroup(int systemId, string companyId);
        List<Extend_LinkGroup> GetLinkGroupByState(int systemId, string companyId, string state);

    }
}
