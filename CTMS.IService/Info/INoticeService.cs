using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Info
{
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    public partial interface INoticeService:IBaseService<Info_Notice>
    {
        bool SaveNotice(Info_Notice entity);
        bool UpdateNotice(Info_Notice entity);
        bool UpdateNoticeState(int systemId, string companyId, string noticeId, bool state);
        bool DeleteNotice(int systemId, string companyId, string noticeId);
        Info_Notice GetNotice(int systemId, string companyId, string noticeId);
        List<Info_Notice> GetNoticeTop(int systemId, string companyId, int count);
        List<Info_Notice> GetNoticeTop(int systemId, string companyId, string state, int count);
        List<Info_Notice> GetNoticeTop(int systemId, string companyId, string classId, string state, int count);
        List<Info_Notice> GetNoticePaging(int systemId, string companyId, int pageId, int pageSize);
        List<Info_Notice> GetNoticePaging(int systemId, string companyId, string state, int pageId, int pageSize);
        List<Info_Notice> GetNoticePaging(int systemId, string companyId, string classId, string state, int pageId, int pageSize);
        List<Info_Notice> SearchNotice(int systemId, string companyId, string startTime, string endTime, string classId, string state, string keyword, int count);
        long CountNotice(int systemId, string companyId);
        long CountNotice(int systemId, string companyId, string classId, string state);
        long CountNotice(int systemId, string companyId, string startTime, string endTime, string classId, string state, string keyword);

    }
}
