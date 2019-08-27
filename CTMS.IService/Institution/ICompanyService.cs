using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Institution
{
    using CTMS.DbModels;
    using CTMS.DbViews;
    using CTMS.DbStoredProcedure;
    public partial interface ICompanyService:IBaseService<Institution_Company>
    {
        bool SaveCompanyRegisterPro(int systemId, string dealerId, int classId, string companyName, string password, string nickName, string phone, string email, string registerIpAddress);
        bool UpdateCompanyPro(int systemId, string companyId, string companyName, string nickName, string tel, string fax, string phone, string email, string address, string description);
        Institution_Company GetCompanyPro(int systemId, string companyId);
        List<Institution_Company> GetCompanyPagingPro(int systemId, int pageId, int pageSize, out int rowCount);
        List<Institution_Company> GetCompanyTopPro(int systemId, int count);
        List<Institution_Company> SearchCompanyPro(int systemId, string companyId, string startTime, string endTime, string keyword);

    }
}
