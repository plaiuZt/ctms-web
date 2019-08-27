using System;
using System.Linq;
using System.Collections.Generic;

namespace CTMS.Service.Sys
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IService.Sys;
    using CTMS.IDAL.Sys;
    using CTMS.Common.Json;
    using CTMS.Common.Extension;
    /// <summary>
    /// 系统配置业务逻辑服务类
    /// </summary>
    public partial class ConfigService:BaseService<Sys_Config>,IConfigService
    {
        private readonly IConfigDAL ConfigDAL;
        private readonly CTMSContext CTMSContext;
        public ConfigService(CTMSContext CTMSContext, IConfigDAL ConfigDAL)
        {
            this.CTMSContext = CTMSContext;
            this.ConfigDAL = ConfigDAL;
            this.Dal = ConfigDAL;
        }
        public override void SetDal()
        {
            Dal = ConfigDAL;
        }

        public bool UpdateConfig(Sys_Config entity)
        {
            try
            {
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Sys_Config GetConfig(int systemId, string companyId)
        {
            try
            {
                return Find(m => m.SystemID == systemId && m.CompanyID == companyId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateConfigPro(Sys_Config entity)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Update_Sys_Config(entity.SystemID, entity.CompanyID, entity.Title, entity.Keyword, entity.Description, entity.HomeUrl, entity.StyleSrc, entity.UploadRoot, entity.Copyright, entity.IcpNumber, entity.StatisticsCode, entity.IsLoginIpAddress.ToBool(), entity.LoginIpAddressWhiteList, entity.MaxLoginFail.ToInt(), entity.EmailSendPattern, entity.EmailHost, entity.EmailPort.ToInt(), entity.EmailName, entity.EmailPassword, entity.EmailAddress, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateConfigShieldingPro(int systemId, string companyId, string shielding)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Update_Sys_ConfigShielding(systemId, companyId, shielding, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Sys_Config GetConfigPro(int systemId, string companyId)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Sys_Config(systemId, companyId, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                if (result == null)
                    return null;
                else
                    return result.ToObject<List<Sys_Config>>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
