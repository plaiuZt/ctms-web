using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Basics
{
    using CTMS.DbModels;
    using CTMS.DbViews;
    using CTMS.DbStoredProcedure;
    public partial interface IVMediaService: IBaseService<V_Basics_Media>
    {
        V_Basics_Media GetVMedia(int systemId, string companyId, string memberId, string mediaId);

    }
}
