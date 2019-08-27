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
    /// <summary>
    /// 
    /// </summary>
    public partial class CodeService : BaseService<Sys_Code>, ICodeService
    {
        private readonly ICodeDAL CodeDAL;
        private readonly CTMSContext CTMSContext;
        public CodeService(CTMSContext CTMSContext, ICodeDAL CodeDAL)
        {
            this.CTMSContext = CTMSContext;
            this.CodeDAL = CodeDAL;
            this.Dal = CodeDAL;
        }
        public override void SetDal()
        {
            Dal = CodeDAL;
        }

        public bool SaveCodePro(int systemId, string systemName, string description, bool state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Add_Sys_Code(systemId, systemName, description, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteCodePro(int systemId)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Delete_Sys_Code(systemId, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateCodePro(int systemId, string systemName, string description, bool state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Update_Sys_Code(systemId, systemName, description, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateCodeStatePro(int systemId, bool state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Update_Sys_CodeState(systemId, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Sys_Code GetCodePro(int systemId)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Sys_Code(systemId.ToString(), out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                if (result == null)
                    return null;
                else
                    return result.ToObject<List<Sys_Code>>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Sys_Code> GetCodeAllPro()
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Sys_Code("", out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                if (result == null)
                    return null;
                else
                    return result.ToObject<List<Sys_Code>>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
