using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Service
{
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    public partial interface IMessageBoardService:IBaseService<Service_MessageBoard>
    {
        bool SaveMessageBoard(Service_MessageBoard entity);
        bool DeleteMessageBoard(int systemId, string companyId, string messageId);
        bool UpdateMessageBoardState(int systemId, string companyId, string messageId, bool state);
        bool UpdateMessageBoardReply(int systemId, string companyId, string messageId, string reply, string replyStaffId, string replyStaffName, bool state);
        Service_MessageBoard GetMessageBoard(int systemId, string companyId, string messageId);
        List<Service_MessageBoard> GetMessageBoardTop(int systemId, string companyId, int count);
        List<Service_MessageBoard> GetMessageBoardPaging(int systemId, string companyId, int pageId, int pageSize);
        List<Service_MessageBoard> GetMessageBoardPaging(int systemId, string companyId, string state, int pageId, int pageSize);
        List<Service_MessageBoard> SearchMessageBoard(int systemId, string companyId, string startTime, string endTime, string state, string keyword, int count);
        long CountMessageBoard(int systemId, string companyId);
        long CountMessageBoard(int systemId, string companyId, string state);


    }
}
