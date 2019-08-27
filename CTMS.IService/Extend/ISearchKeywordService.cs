using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Extend
{
    using CTMS.DbModels;
    using CTMS.Model.Extend;

    public partial interface ISearchKeywordService:IBaseService<Extend_SearchKeyword>
    {
        bool SaveSearchKeyword(Extend_SearchKeyword entity);
        bool UpdateSearchKeywordState(long id, bool state);
        bool UpdateSearchKeywordTop(long id, bool top);
        bool DeleteSearchKeyword(long id);
        Extend_SearchKeyword GetSearchKeyword(long id);
        List<Extend_SearchKeyword> GetSearchKeyword(int systemId, string companyId, int count);
        List<Extend_SearchKeyword> GetSearchKeywordByKeyword(int systemId, string companyId, string keyword, int count);
        List<Extend_SearchKeyword> GetSearchKeywordByTop(int systemId, string companyId, string memberId, int count);
        List<Extend_SearchKeyword> SearchSearchKeyword(int systemId, string companyId, string startTime, string endTime, string keyword, int count);
        List<CountSearchKeywordByKeywordResult> CountSearchKeywordByKeyword(int systemId, string companyId, int count);
        List<CountSearchKeywordByKeywordResult> CountSearchKeywordByKeyword(int systemId, string companyId, string startTime, string endTime, string keyword, int count);
        long CountSearchKeyword(int systemId, string companyId);

    }
}
