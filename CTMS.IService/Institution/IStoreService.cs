using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Institution
{
    using CTMS.DbModels;
    using CTMS.DbViews;
    using CTMS.DbStoredProcedure;
    public partial interface IStoreService:IBaseService<Institution_Store>
    {
        bool SaveStorePro(int systemId, string companyId, string storeId, string storeName, string logo, string contacts, string tel, string fax, string phone, string email, int provinceId, int cityId, int areaId, string address, string keyword, string description, DateTime startTime, DateTime endTime, bool push, int sort, bool state);
        bool UpdateStorePro(int systemId, string companyId, string storeId, string storeName, string logo, string contacts, string tel, string fax, string phone, string email, int provinceId, int cityId, int areaId, string address, string keyword, string description, DateTime startTime, DateTime endTime, bool push, int sort, bool state);
        bool UpdateStoreStatePro(int systemId, string companyId, string storeId, bool state);
        bool DeleteStorePro(int systemId, string companyId, string storeId);
        Institution_Store GetStorePro(int systemId, string companyId, string storeId);
        List<Institution_Store> GetStoreByStatePro(int systemId, string companyId, string state);
        List<Institution_Store> GetStorePagingPro(int systemId, string companyId, int pageId, int pageSize, out int rowCount);
        List<Institution_Store> SearchStorePro(int systemId, string companyId, string startTime, string endTime, string keyword);
    }
}
