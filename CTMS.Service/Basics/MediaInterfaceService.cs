using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Service.Basics
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IDAL.Basics;
    using CTMS.Common.Json;
    using CTMS.IService.Basics;

    /// <summary>
    /// 
    /// </summary>
    public partial class MediaInterfaceService:BaseService<Basics_MediaInterface>,IMediaInterfaceService
    {
        private readonly IMediaInterfaceDAL MediaInterfaceDAL;
        private readonly CTMSContext CTMSContext;
        public MediaInterfaceService(CTMSContext CTMSContext, IMediaInterfaceDAL MediaInterfaceDAL)
        {
            this.CTMSContext = CTMSContext;
            this.MediaInterfaceDAL = MediaInterfaceDAL;
            this.Dal = MediaInterfaceDAL;
        }
        public override void SetDal()
        {
            Dal = MediaInterfaceDAL;
        }



    }
}
