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
    public partial class WarehouseService:BaseService<Institution_Warehouse>,IWarehouseService
    {
        private readonly IWarehouseDAL WarehouseDAL;
        private readonly CTMSContext CTMSContext;
        public WarehouseService(CTMSContext CTMSContext, IWarehouseDAL WarehouseDAL)
        {
            this.CTMSContext = CTMSContext;
            this.WarehouseDAL = WarehouseDAL;
            this.Dal = WarehouseDAL;
        }
        public override void SetDal()
        {
            Dal = WarehouseDAL;
        }

    }
}
