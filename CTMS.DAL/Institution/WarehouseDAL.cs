using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Institution
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IDAL.Institution;
    public partial class WarehouseDAL:BaseDAL<Institution_Warehouse>,IWarehouseDAL
    {
        public WarehouseDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
