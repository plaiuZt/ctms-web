using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Extend
{
    using CTMS.DbModels;
    public partial interface IAdvertisementDetailsService : IBaseService<Extend_AdvertisementDetails>
    {
        bool SaveAdvertisementDetails(Extend_AdvertisementDetails entity);
        bool UpdateAdvertisementDetails(Extend_AdvertisementDetails entity);
        bool DeleteAdvertisementDetails(int systemId, string companyId, string detailsId);
        bool DeleteAdvertisementDetailsByAdvertisementId(int systemId, string companyId, string advertisementId);
        Extend_AdvertisementDetails GetAdvertisementDetails(int systemId, string companyId, string detailsId);
        List<Extend_AdvertisementDetails> GetAdvertisementDetailsByAdvertisementId(int systemId, string companyId, string advertisementId);

    }
}
