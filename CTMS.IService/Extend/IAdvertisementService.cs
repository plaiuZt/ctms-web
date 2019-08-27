using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Extend
{
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    public partial interface IAdvertisementService:IBaseService<Extend_Advertisement>
    {
        bool SaveAdvertisement(Extend_Advertisement entity, List<Extend_AdvertisementDetails> lists);
        bool UpdateAdvertisement(Extend_Advertisement entity, List<Extend_AdvertisementDetails> lists);
        bool UpdateAdvertisementState(int systemId, string companyId, string advertisementId, bool state);
        bool UpdateAdvertisementSort(int systemId, string companyId, string advertisementId, int sort);
        bool DeleteAdvertisement(int systemId, string companyId, string advertisementId);
        Extend_Advertisement GetAdvertisement(int systemId, string companyId, string advertisementId);
        List<Extend_Advertisement> GetAdvertisementTop(int systemId, string companyId, int count);
        List<Extend_Advertisement> GetAdvertisementPaging(int systemId, string companyId, int pageId, int pageSize);
        List<Extend_Advertisement> SearchAdvertisement(int systemId, string companyId, string startTime, string endTime, string state, string keyword, int count);
        long CountAdvertisement(int systemId, string companyId);
        long CountAdvertisement(int systemId, string companyId, string startTime, string endTime, string state, string keyword);


    }
}
