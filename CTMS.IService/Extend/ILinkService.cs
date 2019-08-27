using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Extend
{
    using CTMS.DbModels;
    public partial interface ILinkService:IBaseService<Extend_Link>
    {
        bool SaveLink(Extend_Link entity);
        bool UpdateLink(Extend_Link entity);
        bool UpdateLinkState(int systemId, string companyId, string linkId, bool state);
        bool UpdateLinkSort(int systemId, string companyId, string linkId, int sort);
        bool DeleteLink(int systemId, string companyId, string linkId);
        Extend_Link GetLink(int systemId, string companyId, string linkId);
        List<Extend_Link> GetLinkTop(int systemId, string companyId, int count);
        List<Extend_Link> GetLinkTop(int systemId, string companyId, string typeId, string state, int count);
        List<Extend_Link> GetLinkTop(int systemId, string companyId, string groupId, string typeId, string state, int count);
        List<Extend_Link> GetLinkPaging(int systemId, string companyId, int pageId, int pageSize);
        List<Extend_Link> GetLinkPaging(int systemId, string companyId, string groupId, string typeId, string state, int pageId, int pageSize);
        List<Extend_Link> SearchLink(int systemId, string companyId, string startTime, string endTime, string state, string keyword, int count);
        long CountLink(int systemId, string companyId);
        long CountLink(int systemId, string companyId, string groupId, string typeId, string state);
        long CountLink(int systemId, string companyId, string startTime, string endTime, string state, string keyword);
    }
}
