using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Service.Institution
{
    using CTMS.DbModels;
    using CTMS.DbViews;
    using CTMS.DbStoredProcedure;
    using CTMS.DbContexts;
    using CTMS.IService.Institution;
    using CTMS.IDAL.Institution;
    using CTMS.Common.Json;
    public partial class DealerService:BaseService<Institution_Dealer>,IDealerService
    {
        private readonly IDealerDAL DealerDAL;
        private readonly CTMSContext CTMSContext;
        public DealerService(CTMSContext CTMSContext, IDealerDAL DealerDAL)
        {
            this.CTMSContext = CTMSContext;
            this.DealerDAL = DealerDAL;
            this.Dal = DealerDAL;
        }
        public override void SetDal()
        {
            Dal = DealerDAL;
        }

    }
}
