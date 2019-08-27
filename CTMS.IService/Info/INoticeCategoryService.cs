using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Info
{
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    public partial interface INoticeCategoryService:IBaseService<Info_NoticeCategory>
    {
        bool SaveNoticeCategory(Info_NoticeCategory entity);
        bool UpdateNoticeCategory(Info_NoticeCategory entity);
        bool UpdateNoticeCategoryState(int systemId, string companyId, string categoryId, bool state);
        bool DeleteNoticeCategory(int systemId, string companyId, string categoryId);
        Info_NoticeCategory GetNoticeCategory(int systemId, string companyId, string categoryId);
        List<Info_NoticeCategory> GetNoticeCategory(int systemId, string companyId);
        List<Info_NoticeCategory> GetNoticeCategoryByState(int systemId, string companyId, string state);


    }
}
