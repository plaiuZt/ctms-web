using System;
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
    /// <summary>
    /// 
    /// </summary>
    public partial class VersionService:BaseService<Sys_Version>,IVersionService
    {
        private readonly IVersionDAL VersionDAL;
        private readonly CTMSContext CTMSContext;
        public VersionService(CTMSContext CTMSContext, IVersionDAL VersionDAL)
        {
            this.CTMSContext = CTMSContext;
            this.VersionDAL = VersionDAL;
            this.Dal = VersionDAL;
        }
        public override void SetDal()
        {
            Dal = VersionDAL;
        }

        public bool SaveVersionPro(string versionId, string versionName, decimal marketPrice, decimal dealerPrice, int departmentTotalQuantity, int staffTotalQuantity, int storeTotalQuantity, int warehouseTotalQuantity, string description, bool state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Add_Sys_Version(versionId, versionName, marketPrice, dealerPrice, departmentTotalQuantity, staffTotalQuantity, storeTotalQuantity, warehouseTotalQuantity, description, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteVersionPro(string versionId)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Delete_Sys_Version(versionId, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateVersionPro(string versionId, string versionName, decimal marketPrice, decimal dealerPrice, int departmentTotalQuantity, int staffTotalQuantity, int storeTotalQuantity, int warehouseTotalQuantity, string description, bool state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Update_Sys_Version(versionId, versionName, marketPrice, dealerPrice, departmentTotalQuantity, staffTotalQuantity, storeTotalQuantity, warehouseTotalQuantity, description, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateVersionStatePro(string versionId, bool state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Update_Sys_VersionState(versionId, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<SP_Get_Sys_Version> GetVersionPro(string versionId)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Sys_Version(versionId, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                if (result == null)
                    return null;
                else
                    return result.ToObject<List<SP_Get_Sys_Version>>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<SP_Get_Sys_Version> GetVersionAllPro()
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Sys_Version("", out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                if (result == null)
                    return null;
                else
                    return result.ToObject<List<SP_Get_Sys_Version>>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
