using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Service.Basics
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbViews;
    using CTMS.DbStoredProcedure;
    using CTMS.IService.Basics;
    using CTMS.IDAL.Basics;
    using CTMS.Common.Json;
    public partial class VMediaService : BaseService<V_Basics_Media>, IVMediaService
    {
        private readonly IVMediaDAL VMediaDAL;
        private readonly CTMSContext CTMSContext;
        public VMediaService(CTMSContext CTMSContext, IVMediaDAL VMediaDAL)
        {
            this.CTMSContext = CTMSContext;
            this.VMediaDAL = VMediaDAL;
            this.Dal = VMediaDAL;
        }
        public override void SetDal()
        {
            Dal = VMediaDAL;
        }

        public V_Basics_Media GetVMedia(int systemId, string companyId, string memberId, string mediaId)
        {
            try
            {
                return Find(m => m.SystemID == systemId && m.CompanyID == companyId && m.MemberID == memberId && m.MediaID == mediaId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
