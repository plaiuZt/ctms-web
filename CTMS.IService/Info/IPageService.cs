using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Info
{
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    public partial interface IPageService:IBaseService<Info_Page>
    {
        bool SavePage(Info_Page entity);
        bool UpdatePage(Info_Page entity);
        bool UpdatePageState(int systemId, string companyId, string pageId, bool state);
        bool UpdatePageSort(int systemId, string companyId, string pageId, int sort);
        bool DeletePage(int systemId, string companyId, string pageId);
        Info_Page GetPage(int systemId, string companyId, string pageId);
        Info_Page GetPageByClassId(int systemId, string companyId, string classId);
        List<Info_Page> GetPage(int systemId, string companyId, string classId, string state);
        List<Info_Page> GetPageTop(int systemId, string companyId, int count);
        List<Info_Page> GetPagePaging(int systemId, string companyId, int pageId, int pageSize);
        List<Info_Page> SearchPage(int systemId, string companyId, string startTime, string endTime, string classId, string state, string keyword, int count);
        long CountPage(int systemId, string companyId);

    }
}
