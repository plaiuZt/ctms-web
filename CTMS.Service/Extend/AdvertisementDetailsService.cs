using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Service.Extend
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IService.Extend;
    using CTMS.IDAL.Extend;
    using CTMS.Common.Json;
    using CTMS.Common.Security;
    using CTMS.Common.Extension;
    /// <summary>
    /// 
    /// </summary>
    public partial class AdvertisementDetailsService : BaseService<Extend_AdvertisementDetails>, IAdvertisementDetailsService
    {
        private readonly IAdvertisementDetailsDAL AdvertisementGroupDAL;
        private readonly CTMSContext CTMSContext;
        public AdvertisementDetailsService(CTMSContext CTMSContext, IAdvertisementDetailsDAL AdvertisementGroupDAL)
        {
            this.CTMSContext = CTMSContext;
            this.AdvertisementGroupDAL = AdvertisementGroupDAL;
            this.Dal = AdvertisementGroupDAL;
        }
        public override void SetDal()
        {
            Dal = AdvertisementGroupDAL;
        }

        public bool SaveAdvertisementDetails(Extend_AdvertisementDetails entity)
        {
            try
            {
                var advertisementDetails = PrimaryKeyHelper.PrimaryKeyType.ExtendAdvertisementDetails;
                var version = PrimaryKeyHelper.PrimaryKeyLen.V1;
                string advertisementDetailsId = PrimaryKeyHelper.MakePrimaryKey(advertisementDetails, version);
                entity.DetailsID = advertisementDetailsId;
                entity.Sort = entity.Sort.ToInt();
                entity.State = entity.State.ToBool();
                entity.CreateDate = DateTime.Now;
                return Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateAdvertisementDetails(Extend_AdvertisementDetails entity)
        {
            try
            {
                entity.Sort = entity.Sort.ToInt();
                entity.State = entity.State.ToBool();
                entity.CreateDate = DateTime.Now;
                return Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteAdvertisementDetails(int systemId, string companyId, string detailsId)
        {
            try
            {
                var expression = ExtLinq.True<Extend_AdvertisementDetails>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.DetailsID == detailsId);
                if (!IsExists(expression))
                    throw new Exception("主建ID无效！");
                return Delete(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteAdvertisementDetailsByAdvertisementId(int systemId, string companyId, string advertisementId)
        {
            try
            {
                var expression = ExtLinq.True<Extend_AdvertisementDetails>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.AdvertisementID == advertisementId);
                if (!IsExists(expression))
                    throw new Exception("主建ID无效！");
                return Delete(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Extend_AdvertisementDetails GetAdvertisementDetails(int systemId, string companyId, string detailsId)
        {
            try
            {
                var expression = ExtLinq.True<Extend_AdvertisementDetails>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.DetailsID == detailsId);
                if (!IsExists(expression))
                    throw new Exception("主建ID无效！");
                return Find(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Extend_AdvertisementDetails> GetAdvertisementDetailsByAdvertisementId(int systemId, string companyId, string advertisementId)
        {
            try
            {
                var expression = ExtLinq.True<Extend_AdvertisementDetails>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.AdvertisementID == advertisementId);
                return FindList(expression, m => m.Sort.Value, true).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
