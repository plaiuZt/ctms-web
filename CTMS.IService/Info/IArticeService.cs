using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Info
{
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    public partial interface IArticeService:IBaseService<Info_Artice>
    {

        bool SaveArtice(Info_Artice entity);
        bool UpdateArtice(Info_Artice entity);
        bool UpdateArticeState(int systemId, string companyId, string articeId, bool state);
        bool UpdateArticeHits(int systemId, string companyId, string articeId);
        bool UpdateArticeUpNum(int systemId, string companyId, string articeId);
        bool UpdateArticeDownNum(int systemId, string companyId, string articeId);
        bool UpdateArticeDelete(int systemId, string companyId, string articeId, bool delete);
        bool DeleteArtice(int systemId, string companyId, string articeId);
        Info_Artice GetArtice(int systemId, string companyId, string articeId);
        List<Info_Artice> GetArticeTop(int systemId, string companyId, bool delete, int count);
        List<Info_Artice> GetArticeTop(int systemId, string companyId, string classId, bool delete, int count);
        List<Info_Artice> GetArticeTop(int systemId, string companyId, string classId, string state, bool delete, int count);
        List<Info_Artice> GetArticePaging(int systemId, string companyId, bool delete, int pageId, int pageSize);
        List<Info_Artice> GetArticePaging(int systemId, string companyId, string classId, bool delete, int pageId, int pageSize);
        List<Info_Artice> GetArticePaging(int systemId, string companyId, string classId, string state, bool delete, int pageId, int pageSize);
        List<Info_Artice> SearchArtice(int systemId, string companyId, string keyword, int count);
        List<Info_Artice> SearchArtice(int systemId, string companyId, string startTime, string endTime, string classId, string state, string keyword, bool delete, int count);
        long CountArtice(int systemId, string companyId, bool delete);
        long CountArtice(int systemId, string companyId, string classId, bool delete);
        long CountArtice(int systemId, string companyId, string classId, string state, bool delete);
        long CountArtice(int systemId, string companyId, string keyword);
        long CountArtice(int systemId, string companyId, string startTime, string endTime, string classId, string state, string keyword, bool delete);

    }
}
