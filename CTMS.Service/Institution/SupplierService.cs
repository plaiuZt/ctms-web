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
    public partial class SupplierService:BaseService<Institution_Supplier>,ISupplierService
    {
        private readonly ISupplierDAL SupplierDAL;
        private readonly CTMSContext CTMSContext;
        public SupplierService(CTMSContext CTMSContext, ISupplierDAL SupplierDAL)
        {
            this.CTMSContext = CTMSContext;
            this.SupplierDAL = SupplierDAL;
            this.Dal = SupplierDAL;
        }
        public override void SetDal()
        {
            Dal = SupplierDAL;
        }

    }
}
