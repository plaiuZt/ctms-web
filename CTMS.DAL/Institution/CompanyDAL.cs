using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Institution
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IDAL.Institution;
    public partial class CompanyDAL:BaseDAL<Institution_Company>,ICompanyDAL
    {
        public CompanyDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
