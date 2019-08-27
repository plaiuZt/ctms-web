using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Service.Member
{
    using CTMS.DbModels;
    using CTMS.DbContexts;
    using CTMS.DbStoredProcedure;
    using CTMS.IService.Member;
    using CTMS.IDAL.Member;
    /// <summary>
    /// 
    /// </summary>
    public partial class InvoiceService:BaseService<Member_Invoice>,IInvoiceService
    {
        private readonly IInvoiceDAL InvoiceDAL;
        private readonly CTMSContext CTMSContext;
        public InvoiceService(CTMSContext CTMSContext, IInvoiceDAL InvoiceDAL)
        {
            this.CTMSContext = CTMSContext;
            this.InvoiceDAL = InvoiceDAL;
            this.Dal = InvoiceDAL;
        }
        public override void SetDal()
        {
            Dal = InvoiceDAL;
        }

    }
}
