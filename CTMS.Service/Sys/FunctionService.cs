using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CTMS.Service.Sys
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IService.Sys;
    using CTMS.IDAL.Sys;
    using CTMS.Common.Json;


    public partial class FunctionService : BaseService<Sys_Function>, IFunctionService
    {
        private readonly IFunctionDAL FunctionDAL;
        private readonly CTMSContext CTMSContext;
        public FunctionService(CTMSContext CTMSContext, IFunctionDAL FunctionDAL)
        {
            this.CTMSContext = CTMSContext;
            this.FunctionDAL = FunctionDAL;
            this.Dal = FunctionDAL;
        }
        public override void SetDal()
        {
            Dal = FunctionDAL;
        }

        public bool SaveFunctionPro(string functionId, string functionName, string parentId, int rankId, bool state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Add_Sys_Function(functionId, functionName, parentId, rankId, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateFunctionPro(string functionId, string functionName, bool state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Update_Sys_Function(functionId, functionName, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateFunctionStatePro(string functionId, bool state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Update_Sys_FunctionState(functionId, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteFunctionPro(string functionId)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Delete_Sys_Function(functionId, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Sys_Function GetFunctionPro(string functionId)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Sys_Function(functionId, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result == null ? null : result.ToObject<List<Sys_Function>>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Sys_Function> GetFunctionByParentIdPro(string parentId)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Sys_FunctionByParentId(parentId, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return result == null ? null : result.ToObject<List<Sys_Function>>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
