using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Institution
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IDAL.Institution;
    public partial class SupplierDAL:BaseDAL<Institution_Supplier>,ISupplierDAL
    {
        public SupplierDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
