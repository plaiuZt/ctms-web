using System;
using System.Linq;
using System.Linq.Expressions;
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
    using CTMS.Common.Utility;
    /// <summary>
    /// 
    /// </summary>
    public partial class AdvertisementService:BaseService<Extend_Advertisement>,IAdvertisementService
    {
        private readonly IAdvertisementDAL AdvertisementDAL;
        private readonly CTMSContext CTMSContext;
        public AdvertisementService(CTMSContext CTMSContext, IAdvertisementDAL AdvertisementDAL)
        {
            this.CTMSContext = CTMSContext;
            this.AdvertisementDAL = AdvertisementDAL;
            this.Dal = AdvertisementDAL;
        }
        public override void SetDal()
        {
            Dal = AdvertisementDAL;
        }


        public bool SaveAdvertisement(Extend_Advertisement entity,  List<Extend_AdvertisementDetails> lists)
        {
            try
            {
                var advertisement = PrimaryKeyHelper.PrimaryKeyType.ExtendAdvertisement;
                var advertisementDetails = PrimaryKeyHelper.PrimaryKeyType.ExtendAdvertisementDetails;
                var version = PrimaryKeyHelper.PrimaryKeyLen.V1;
                string advertisementId = PrimaryKeyHelper.MakePrimaryKey(advertisement, version);

                entity.AdvertisementID = advertisementId;
                entity.Sort = entity.Sort.ToInt();
                entity.State = entity.State.ToBool();
                entity.CreateDate = DateTime.Now;

                if (lists == null)
                    throw new Exception("广告列表不能为空！");

                List<Extend_AdvertisementDetails> details = new List<Extend_AdvertisementDetails>();
                foreach (var m in lists)
                {
                    string advertisementDetailsId = PrimaryKeyHelper.MakePrimaryKey(advertisementDetails, version);
                    m.SystemID = entity.SystemID;
                    m.CompanyID = entity.CompanyID;
                    m.DetailsID = advertisementDetailsId;
                    m.AdvertisementID = advertisementId;
                    m.Sort = m.Sort.ToInt();
                    m.State = m.State.ToBool();
                    m.CreateDate = DateTime.Now;
                    details.Add(m);
                }

                int intnum = 0;
                var dbContext = new DAL.BaseDAL(CTMSContext);
                using (var db = dbContext.DbEntities())
                {
                    //using (var trans = db.Database.BeginTransaction())
                    //{
                    //    try
                    //    {
                    //        dbContext.Add(entity);
                    //        dbContext.Add(details);
                    //        intnum = db.SaveChanges();
                    //        trans.Commit();
                    //    }
                    //    catch (Exception)
                    //    {
                    //        trans.Rollback();
                    //    }
                    //    return intnum > 0;
                    //}

                    db.Orm.Transaction(() => 
                    {
                        dbContext.Add(entity);
                        dbContext.Add(details);
                        intnum = db.SaveChanges();
                    });
                }
                return intnum > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateAdvertisement(Extend_Advertisement entity, List<Extend_AdvertisementDetails> lists)
        {
            try
            {
                var advertisementDetails = PrimaryKeyHelper.PrimaryKeyType.ExtendAdvertisementDetails;
                var version = PrimaryKeyHelper.PrimaryKeyLen.V1;
                int systemId = entity.SystemID;
                string companyId = entity.CompanyID;
                string advertisementId = entity.AdvertisementID;
                entity.Sort = entity.Sort.ToInt();
                entity.State = entity.State.ToBool();
                entity.CreateDate = DateTime.Now;

                if (lists == null)
                    throw new Exception("广告列表不能为空！");
                List<Extend_AdvertisementDetails> details = new List<Extend_AdvertisementDetails>();
                foreach (var m in lists)
                {
                    string advertisementDetailsId = PrimaryKeyHelper.MakePrimaryKey(advertisementDetails, version);
                    m.SystemID = entity.SystemID;
                    m.CompanyID = entity.CompanyID;
                    m.DetailsID = advertisementDetailsId;
                    m.AdvertisementID = advertisementId;
                    m.Sort = m.Sort.ToInt();
                    m.State = m.State.ToBool();
                    m.CreateDate = DateTime.Now;
                    details.Add(m);
                }
                var expression = ExtLinq.True<Extend_AdvertisementDetails>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.AdvertisementID == advertisementId);

                int intnum = 0;
                var dbContext = new DAL.BaseDAL(CTMSContext);
                using (var db = dbContext.DbEntities())
                {
                    //using (var trans = db.Database.BeginTransaction())
                    //{
                    //    try
                    //    {
                    //        dbContext.Update(entity);
                    //        dbContext.Delete(expression);
                    //        dbContext.Add(details);
                    //        intnum = db.SaveChanges();
                    //        trans.Commit();
                    //    }
                    //    catch (Exception)
                    //    {
                    //        trans.Rollback();
                    //    }
                    //    return intnum > 0;
                    //}
                    db.Orm.Transaction(()=>
                    {
                        dbContext.Update(entity);
                        dbContext.Delete(expression);
                        dbContext.Add(details);
                        intnum = db.SaveChanges();
                    });
                    return intnum > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateAdvertisementState(int systemId, string companyId, string advertisementId, bool state)
        {
            try
            {
                var entity = Find(m => m.SystemID == systemId && m.CompanyID == companyId && m.AdvertisementID == advertisementId);
                if (entity == null)
                    throw new Exception("id invalid！");
                entity.State = state;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateAdvertisementSort(int systemId, string companyId, string advertisementId, int sort)
        {
            try
            {
                var entity = Find(m => m.SystemID == systemId && m.CompanyID == companyId && m.AdvertisementID == advertisementId);
                if (entity == null)
                    throw new Exception("id invalid！");
                entity.Sort = sort;
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteAdvertisement(int systemId, string companyId, string advertisementId)
        {
            try
            {
                var expressionAdvertisement = ExtLinq.True<Extend_Advertisement>();
                expressionAdvertisement = expressionAdvertisement.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.AdvertisementID == advertisementId);
                var expressionAdvertisementDetails = ExtLinq.True<Extend_AdvertisementDetails>();
                expressionAdvertisementDetails = expressionAdvertisementDetails.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.AdvertisementID == advertisementId);

                int intnum = 0;
                var dbContext = new DAL.BaseDAL(CTMSContext);
                using (var db = dbContext.DbEntities())
                {
                    //using (var trans = db.Database.BeginTransaction())
                    //{
                    //    try
                    //    {
                    //        dbContext.Delete(expressionAdvertisement);
                    //        dbContext.Delete(expressionAdvertisementDetails);
                    //        intnum = db.SaveChanges();
                    //        trans.Commit();
                    //    }
                    //    catch (Exception)
                    //    {
                    //        trans.Rollback();
                    //    }
                    //    return intnum > 0;
                    //}

                    db.Orm.Transaction(()=>
                    {
                        dbContext.Delete(expressionAdvertisement);
                        dbContext.Delete(expressionAdvertisementDetails);
                        intnum = db.SaveChanges();
                    });
                    return intnum > 0;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Extend_Advertisement GetAdvertisement(int systemId, string companyId, string advertisementId)
        {
            try
            {
                var expression = ExtLinq.True<Extend_Advertisement>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.AdvertisementID == advertisementId);
                if (!IsExists(expression))
                    throw new Exception("主建ID无效！");
                return Find(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Extend_Advertisement> GetAdvertisementTop(int systemId, string companyId, int count)
        {
            try
            {
                var expression = ExtLinq.True<Extend_Advertisement>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId);
                return FindListTop(expression, m => m.CreateDate, false, count).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Extend_Advertisement> GetAdvertisementPaging(int systemId, string companyId, int pageId, int pageSize)
        {
            try
            {
                var expression = ExtLinq.True<Extend_Advertisement>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId);
                int pageIndex =Utility.ToPageIndex(pageId);
                int pageCount = Utility.ToPageCount(pageSize);
                return FindListPaging(expression, m => m.CreateDate, false, pageIndex, pageCount).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Extend_Advertisement> SearchAdvertisement(int systemId, string companyId, string startTime, string endTime, string state, string keyword, int count)
        {
            try
            {
                DateTime dateStartTime = Utility.ToStartTime(startTime);
                DateTime dateEndTime = Utility.ToEndTime(endTime);
                bool blnState = state.ToBool();
                int total = Utility.ToTopTotal(count);
                //条件
                var expression = ExtLinq.True<Extend_Advertisement>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && m.CreateDate.Value.Date >= dateStartTime.Date && m.CreateDate.Value.Date <= dateEndTime.Date
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == blnState)
                && (m.Name.Contains(keyword) || m.Remark.Contains(keyword)));
                //执行
                return FindListTop(expression, m => m.CreateDate, false, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long CountAdvertisement(int systemId, string companyId)
        {
            try
            {
                var expression = ExtLinq.True<Extend_Advertisement>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId);
                return Count(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long CountAdvertisement(int systemId, string companyId, string startTime, string endTime, string state, string keyword)
        {
            try
            {
                DateTime dateStartTime = Utility.ToStartTime(startTime);
                DateTime dateEndTime = Utility.ToEndTime(endTime);
                bool blnState = state.ToBool();
                var expression = ExtLinq.True<Extend_Advertisement>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && m.CreateDate.Value.Date >= dateStartTime.Date && m.CreateDate.Value.Date <= dateEndTime.Date
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == blnState)
                && (m.Name.Contains(keyword) || m.Remark.Contains(keyword)));
                return Count(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
