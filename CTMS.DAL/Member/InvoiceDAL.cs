using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Member
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using IDAL.Member;

    public partial class InvoiceDAL : BaseDAL<Member_Invoice>, IInvoiceDAL
    {
        public InvoiceDAL(CTMSContext dbContext) : base(dbContext)
        {
        }

    }
}
