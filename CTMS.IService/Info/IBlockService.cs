using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.IService.Info
{
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    public partial interface IBlockService:IBaseService<Info_Block>
    {
        bool SaveBlock(Info_Block entity);
        bool UpdateBlock(Info_Block entity);
        bool UpdateBlockState(int systemId, string companyId, string blockId, bool state);
        bool DeleteBlock(int systemId, string companyId, string blockId);
        Info_Block GetBlock(int systemId, string companyId, string blockId);
        Info_Block GetBlock(int systemId, string companyId, string tags, string state);
        List<Info_Block> GetBlockAll(int systemId, string companyId, string state);
        List<Info_Block> GetBlockPaging(int systemId, string companyId, int pageId, int pageSize);
        List<Info_Block> SearchBlock(int systemId, string companyId, string startTime, string endTime, string state, string keyword, int count);
        long CountBlock(int systemId, string companyId);
        long CountBlock(int systemId, string companyId, string startTime, string endTime, string state, string keyword);

    }
}
