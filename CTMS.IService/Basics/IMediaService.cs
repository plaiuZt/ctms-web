using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Basics
{
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    public partial interface IMediaService:IBaseService<Basics_Media>
    {
        bool SaveMedia(Basics_Media entity);
        int MediaInterface(string appId, Basics_Media entity);
        int MediaInterface(string appId, List<Basics_Media> lists);
        int SaveMediaMember(string memberId, Basics_Media entity);
        int SaveMediaMember(string memberId, List<Basics_Media> lists);

    }
}
