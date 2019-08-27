using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Info
{
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    public partial interface IClassService :IBaseService<Info_Class>
    {
        bool SaveClass(Info_Class entity);
        bool UpdateClass(int systemId, string companyId, string classId, string className, string imgSrc, string keyword, string description, bool state);
        bool UpdateClassState(int systemId, string companyId, string classId, bool state);
        bool UpdateClassOrderId(int systemId, string companyId, string classId, int sort);
        int DeleteClass(int systemId, string companyId, string classId);
        Info_Class GetClass(int systemId, string companyId, string classId);
        List<Info_Class> GetClassAll(int systemId, string companyId);
        List<Info_Class> GetClassState(int systemId, string companyId, bool state);
        List<Info_Class> GetClassByParentPath(int systemId, string companyId, string classId, string state);
        List<Info_Class> GetClassByParentPath(int systemId, string companyId, string classId, string typeId, string state);
        List<Info_Class> GetClassByParentId(int systemId, string companyId, string parentId, string state);
        long CountClass(int systemId, string companyId);

    }
}
