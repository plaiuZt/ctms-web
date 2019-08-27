using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Service
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Service;
    /// <summary>
    /// 服务板块 留言板
    /// </summary>
    public partial class MessageBoardDAL:BaseDAL<Service_MessageBoard>,IMessageBoardDAL
    {
        public MessageBoardDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
