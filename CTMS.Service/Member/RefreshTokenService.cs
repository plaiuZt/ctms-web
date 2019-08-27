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
    public partial class RefreshTokenService:BaseService<Member_RefreshToken>,IRefreshTokenService
    {
        private readonly IRefreshTokenDAL RefreshTokenDAL;
        private readonly CTMSContext CTMSContext;
        public RefreshTokenService(CTMSContext CTMSContext, IRefreshTokenDAL RefreshTokenDAL)
        {
            this.CTMSContext = CTMSContext;
            this.RefreshTokenDAL = RefreshTokenDAL;
            this.Dal = RefreshTokenDAL;
        }
        public override void SetDal()
        {
            Dal = RefreshTokenDAL;
        }

    }
}
