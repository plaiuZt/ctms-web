using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTMS.Service.Sys
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IService.Sys;
    using CTMS.IDAL.Sys;
    using CTMS.Common.Json;
    /// <summary>
    /// 
    /// </summary>
    public partial class AccessCorsHostService:BaseService<Sys_AccessCorsHost>,IAccessCorsHostService
    {
        private readonly IAccessCorsHostDAL AccessCorsHostDAL;
        private readonly CTMSContext CTMSContext;
        public AccessCorsHostService(CTMSContext CTMSContext, IAccessCorsHostDAL AccessCorsHostDAL)
        {
            this.CTMSContext = CTMSContext;
            this.AccessCorsHostDAL = AccessCorsHostDAL;
            this.Dal = AccessCorsHostDAL;
        }
        public override void SetDal()
        {
            Dal = AccessCorsHostDAL;
        }

        public bool SaveAccessCorsHostPro(int systemId, string webHost, string remark, string account, string nickname, bool state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Add_Sys_AccessCorsHost(systemId, webHost, remark, account, nickname, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateAccessCorsHostPro(int systemId, string webHost, string remark, bool state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Update_Sys_AccessCorsHost(systemId, webHost, remark, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteAccessCorsHostPro(int systemId, string webHost)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Delete_Sys_AccessCorsHost(systemId, webHost, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Sys_AccessCorsHost GetAccessCorsHostPro(int systemId, string webHost)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Sys_AccessCorsHost(systemId, webHost, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result == null ? null : result.ToObject<List<Sys_AccessCorsHost>>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Sys_AccessCorsHost> GetAccessCorsHostAllPro(int systemId)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Sys_AccessCorsHostAll(systemId, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result == null ? null : result.ToObject<List<Sys_AccessCorsHost>>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
