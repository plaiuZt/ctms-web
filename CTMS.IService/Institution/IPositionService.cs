using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Institution
{
    using CTMS.DbModels;
    using CTMS.DbViews;
    using CTMS.DbStoredProcedure;
    public partial interface IPositionService:IBaseService<Institution_Position>
    {
        bool SavePositionPro(int systemId, string companyId, string positionId, string positionName, string description, int sort, bool state);
        bool UpdatePositionPro(int systemId, string companyId, string positionId, string positionName, string description, int sort, bool state);
        bool UpdatePositionStatePro(int systemId, string companyId, string positionId, bool state);
        bool DeletePositionPro(int systemId, string companyId, string positionId);
        Institution_Position GetPositionPro(int systemId, string companyId, string positionId);
        List<Institution_Position> GetPositionByStatePro(int systemId, string companyId, string state);
        List<Institution_Position> GetPositionPagingPro(int systemId, string companyId, int pageId, int pageSize, out int rowCount);
        List<Institution_Position> SearchPositionPro(int systemId, string companyId, string startTime, string endTime, string keyword);

    }
}
