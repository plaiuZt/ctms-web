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
    public partial class AddressService:BaseService<Member_Address>,IAddressService
    {
        private readonly IAddressDAL AddressDAL;
        private readonly CTMSContext CTMSContext;
        public AddressService(CTMSContext CTMSContext, IAddressDAL AddressDAL)
        {
            this.CTMSContext = CTMSContext;
            this.AddressDAL = AddressDAL;
            this.Dal = AddressDAL;
        }
        public override void SetDal()
        {
            Dal = AddressDAL;
        }



    }
}
