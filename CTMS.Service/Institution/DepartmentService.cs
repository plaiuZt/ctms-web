using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CTMS.Service.Institution
{
    using CTMS.DbModels;
    using CTMS.DbViews;
    using CTMS.DbStoredProcedure;
    using CTMS.DbContexts;
    using CTMS.IService.Institution;
    using CTMS.IDAL.Institution;
    using CTMS.Common.Json;
    public partial class DepartmentService:BaseService<Institution_Department>,IDepartmentService
    {
        private readonly IDepartmentDAL DepartmentDAL;
        private readonly CTMSContext CTMSContext;
        public DepartmentService(CTMSContext CTMSContext, IDepartmentDAL DepartmentDAL)
        {
            this.CTMSContext = CTMSContext;
            this.DepartmentDAL = DepartmentDAL;
            this.Dal = DepartmentDAL;
        }
        public override void SetDal()
        {
            Dal = DepartmentDAL;
        }

        public bool SaveDepartmentPro(int systemId, string companyId, string departmentId, string departmentName, string parentId, string description, bool state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Add_Institution_Department(systemId, companyId, departmentId, departmentName, parentId, description, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return errCode == 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateDepartmentPro(int systemId, string companyId, string departmentId, string departmentName, string description, bool state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Update_Institution_Department(systemId, companyId, departmentId, departmentName, description, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return errCode == 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateDepartmentStatePro(int systemId, string companyId, string departmentId, bool state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Update_Institution_DepartmentState(systemId, companyId, departmentId, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return errCode == 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteDepartmentPro(int systemId, string companyId, string departmentId)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Delete_Institution_Department(systemId, companyId, departmentId, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                return errCode == 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Institution_Department GetDepartmentPro(int systemId, string companyId, string departmentId)
        {
            try
            {
                if (systemId == 0)
                    throw new Exception("系统编号不能为0！");
                if (string.IsNullOrWhiteSpace(companyId))
                    throw new Exception("公司编号不能为空！");
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Institution_Department(systemId, companyId, departmentId, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                if (result == null)
                    return null;
                else
                    return result.ToObject<List<Institution_Department>>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Institution_Department> GetDepartmentByNodePathPro(int systemId, string companyId, string departmentId, string state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Institution_DepartmentByNodePath(systemId, companyId, departmentId, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                if (result == null)
                    return null;
                else
                    return result.ToObject<List<Institution_Department>>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Institution_Department> GetDepartmentByParentIdPro(int systemId, string companyId, string parentId, string state)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Institution_DepartmentByParentId(systemId, companyId, parentId, state, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                if (result == null)
                    return null;
                else
                    return result.ToObject<List<Institution_Department>>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Institution_Department> GetDepartmentPagingPro(int systemId, string companyId, int pageId, int pageSize, out int rowCount)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Get_Institution_DepartmentPaging(systemId, companyId, pageId, pageSize, out errCode, out errMsg, out rowCount);
                if (errCode != 0)
                    throw new Exception(errMsg);
                if (result == null)
                    return null;
                else
                    return result.ToObject<List<Institution_Department>>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Institution_Department> SearchDepartmentPro(int systemId, string companyId, string startTime, string endTime, string keyword)
        {
            try
            {
                int errCode = -1;
                string errMsg = "fail";
                var result = CTMSContext.SP_Search_Institution_Department(systemId, companyId, startTime, endTime, keyword, out errCode, out errMsg);
                if (errCode != 0)
                    throw new Exception(errMsg);
                if (result == null)
                    return null;
                else
                    return result.ToObject<List<Institution_Department>>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
