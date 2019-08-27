using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Service.Sys
{
    using CTMS.Common.Json;
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IService.Sys;
    using CTMS.IDAL.Sys;

    public partial class InterfaceAccountService : BaseService<Sys_InterfaceAccount>, IInterfaceAccountService
    {
        private readonly IInterfaceAccountDAL InterfaceAccountDAL;
        private readonly CTMSContext CTMSContext;
        public InterfaceAccountService(CTMSContext CTMSContext, IInterfaceAccountDAL InterfaceAccountDAL)
        {
            this.CTMSContext = CTMSContext;
            this.InterfaceAccountDAL = InterfaceAccountDAL;
            this.Dal = InterfaceAccountDAL;
        }
        public override void SetDal()
        {
            Dal = InterfaceAccountDAL;
        }

        public bool SaveInterfaceAccountPro(int systemId, string companyId, string account, string password, bool isWcf, bool isWeb, bool isApi, bool isCors, string description, bool state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Add_Sys_InterfaceAccount(systemId, companyId, account, password, isWcf, isWeb, isApi, isCors, description, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteInterfaceAccountPro(int systemId, string companyId, string account)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Delete_Sys_InterfaceAccount(systemId, companyId, account, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateInterfaceAccountPro(int systemId, string companyId, string account, string password, bool isWcf, bool isWeb, bool isApi, bool isCors, string description, bool state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Update_Sys_InterfaceAccount(systemId, companyId, account, password, isWcf, isWeb, isApi, isCors, description, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateInterfaceAccountAppKeyPro(int systemId, string companyId, string account)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Update_Sys_InterfaceAccountAppKey(systemId, companyId, account, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateInterfaceAccountAppSecretPro(int systemId, string companyId, string account)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Update_Sys_InterfaceAccountAppSecret(systemId, companyId, account, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateInterfaceAccountDelPro(int systemId, string companyId, string account, bool isDel)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Update_Sys_InterfaceAccountDel(systemId, companyId, account, isDel, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateInterfaceAccountPasswordPro(int systemId, string companyId, string account, string password)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Update_Sys_InterfaceAccountPassword(systemId, companyId, account, password, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateInterfaceAccountStatePro(int systemId, string companyId, string account, bool state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Update_Sys_InterfaceAccountState(systemId, companyId, account, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Sys_InterfaceAccount GetInterfaceAccountPro(int systemId, string companyId, string account)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Sys_InterfaceAccount(systemId, companyId, account, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                if (result == null)
                    return null;
                else
                    return result.ToObject<List<Sys_InterfaceAccount>>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Sys_InterfaceAccount GetInterfaceAccountByAppIDPro(int systemId, string appId)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Sys_InterfaceAccountByAppID(systemId, appId, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                if (result == null)
                    return null;
                else
                    return result.ToObject<List<Sys_InterfaceAccount>>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Sys_InterfaceAccount GetInterfaceAccountByUuidPro(int systemId, string uuid)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Sys_InterfaceAccountByUuID(systemId, uuid, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                if (result == null)
                    return null;
                else
                    return result.ToObject<List<Sys_InterfaceAccount>>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Sys_InterfaceAccount GetInterfaceAccountByTokenPro(int systemId, string token)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Sys_InterfaceAccountByToken(systemId, token, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                if (result == null)
                    return null;
                else
                    return result.ToObject<List<Sys_InterfaceAccount>>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Sys_InterfaceAccount> GetInterfaceAccountAllPro(int systemId, string companyId)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Sys_InterfaceAccountAll(systemId, companyId, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                if (result == null)
                    return null;
                else
                    return result.ToObject<List<Sys_InterfaceAccount>>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Sys_InterfaceAccount> GetInterfaceAccountPagingPro(int systemId, string companyId, int pageId, int pageSize, out int rowCount)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Sys_InterfaceAccountPaging(systemId, companyId, pageId, pageSize, out errCode, out errMsg, out rowCount);
                if (errCode != 0)
                    throw new Exception(errMsg);
                if (result == null)
                    return null;
                else
                    return result.ToObject<List<Sys_InterfaceAccount>>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Sys_InterfaceAccount> SearchInterfaceAccountPro(int systemId, string companyId, string startTime, string endTime, string keyword)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Search_Sys_InterfaceAccount(systemId, companyId, startTime, endTime, keyword, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                if (result == null)
                    return null;
                else
                    return result.ToObject<List<Sys_InterfaceAccount>>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool VerifyInterfaceAccountPro(int systemId, string companyId, string account, string password, int classId)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Verify_Sys_InterfaceAccount(systemId, companyId, account, password, classId, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return errCode == 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool VerifyInterfaceAccountByAppIDPro(int systemId, string appId, string appSecret)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Verify_Sys_InterfaceAccountByAppID(systemId, appId, appSecret, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return errCode == 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool VerifyInterfaceAccountByUuIDPro(int systemId, string uuid)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Verify_Sys_InterfaceAccountByUuid(systemId, uuid, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return errCode == 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }


}
