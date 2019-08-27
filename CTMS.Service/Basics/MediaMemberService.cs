using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Service.Basics
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IService.Basics;
    using CTMS.IDAL.Basics;
    using CTMS.Common.Json;
    /// <summary>
    /// 
    /// </summary>
    public partial class MediaMemberService:BaseService<Basics_MediaMember>,IMediaMemberService
    {
        private readonly IMediaMemberDAL MediaMemberDAL;
        private readonly CTMSContext CTMSContext;
        public MediaMemberService(CTMSContext CTMSContext, IMediaMemberDAL MediaMemberDAL)
        {
            this.CTMSContext = CTMSContext;
            this.MediaMemberDAL = MediaMemberDAL;
            this.Dal = MediaMemberDAL;
        }
        public override void SetDal()
        {
            Dal = MediaMemberDAL;
        }


    }
}
