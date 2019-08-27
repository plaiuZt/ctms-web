using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTMS.Service.Institution
{
    using CTMS.DbModels;
    using CTMS.DbViews;
    using CTMS.DbStoredProcedure;
    using CTMS.DbContexts;
    using CTMS.IService.Institution;
    using CTMS.IDAL.Institution;
    using CTMS.Common.Json;
    public partial class StoreService:BaseService<Institution_Store>,IStoreService
    {
        private readonly IStoreDAL StoreDAL;
        private readonly CTMSContext CTMSContext;
        public StoreService(CTMSContext CTMSContext, IStoreDAL StoreDAL)
        {
            this.CTMSContext = CTMSContext;
            this.StoreDAL = StoreDAL;
            this.Dal = StoreDAL;
        }
        public override void SetDal()
        {
            Dal = StoreDAL;
        }

        public bool SaveStorePro(int systemId, string companyId, string storeId, string storeName, string logo, string contacts, string tel, string fax, string phone, string email, int provinceId, int cityId, int areaId, string address, string keyword, string description, DateTime startTime, DateTime endTime, bool push, int sort, bool state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Add_Institution_Store(systemId, companyId, storeId, storeName, logo, contacts, tel, fax, phone, email, provinceId, cityId, areaId, address, keyword, description, startTime, endTime, push, sort, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return errCode == 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateStorePro(int systemId, string companyId, string storeId, string storeName, string logo, string contacts, string tel, string fax, string phone, string email, int provinceId, int cityId, int areaId, string address, string keyword, string description, DateTime startTime, DateTime endTime, bool push, int sort, bool state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Update_Institution_Store(systemId, companyId, storeId, storeName, logo, contacts, tel, fax, phone, email, provinceId, cityId, areaId, address, keyword, description, startTime, endTime, push, sort, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return errCode == 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateStoreStatePro(int systemId, string companyId, string storeId, bool state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Update_Institution_StoreState(systemId, companyId, storeId, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return errCode == 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteStorePro(int systemId, string companyId, string storeId)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Delete_Institution_Store(systemId, companyId, storeId, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return errCode == 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Institution_Store GetStorePro(int systemId, string companyId, string storeId)
        {
            try
            {
                if (systemId == 0)
                    throw new Exception("系统编号不能为0！");
                if (string.IsNullOrWhiteSpace(companyId))
                    throw new Exception("公司编号不能为空！");
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Institution_Store(systemId, companyId, storeId, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result == null ? null : result.ToObject<List<Institution_Store>>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Institution_Store> GetStoreByStatePro(int systemId, string companyId, string state)
        {
            try
            {
                if (systemId == 0)
                    throw new Exception("系统编号不能为0！");
                if (string.IsNullOrWhiteSpace(companyId))
                    throw new Exception("公司编号不能为空！");
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Institution_StoreByState(systemId, companyId, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result == null ? null : result.ToObject<List<Institution_Store>>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Institution_Store> GetStorePagingPro(int systemId, string companyId, int pageId, int pageSize, out int rowCount)
        {
            try
            {
                if (systemId == 0)
                    throw new Exception("系统编号不能为0！");
                if (string.IsNullOrWhiteSpace(companyId))
                    throw new Exception("公司编号不能为空！");
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Institution_StorePaging(systemId, companyId, pageId, pageSize, out errCode, out errMsg, out rowCount);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result == null ? null : result.ToObject<List<Institution_Store>>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Institution_Store> SearchStorePro(int systemId, string companyId, string startTime, string endTime, string keyword)
        {
            try
            {
                if (systemId == 0)
                    throw new Exception("系统编号不能为0！");
                if (string.IsNullOrWhiteSpace(companyId))
                    throw new Exception("公司编号不能为空！");
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Search_Institution_Store(systemId, companyId, startTime, endTime, keyword, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result == null ? null : result.ToObject<List<Institution_Store>>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
