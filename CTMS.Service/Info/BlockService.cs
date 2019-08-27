using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Service.Info
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IService.Info;
    using CTMS.IDAL.Info;
    using CTMS.Common.Json;
    using CTMS.Common.Security;
    using CTMS.Common.Extension;
    using CTMS.Common.Utility;

    public partial class BlockService:BaseService<Info_Block>,IBlockService
    {
        private readonly IBlockDAL BlockDAL;
        private readonly CTMSContext CTMSContext;
        public BlockService(CTMSContext CTMSContext, IBlockDAL BlockDAL)
        {
            this.CTMSContext = CTMSContext;
            this.BlockDAL = BlockDAL;
            this.Dal = BlockDAL;
        }
        public override void SetDal()
        {
            Dal = BlockDAL;
        }

        public bool SaveBlock(Info_Block entity)
        {
            try
            {
                var infoBlock = PrimaryKeyHelper.PrimaryKeyType.InfoBlock;
                var primaryKeyLen = PrimaryKeyHelper.PrimaryKeyLen.V1;
                int systemId = entity.SystemID;
                string companyId = entity.CompanyID;
                string blockId = PrimaryKeyHelper.MakePrimaryKey(infoBlock, primaryKeyLen);
                string tags = entity.Tags;
                bool state = entity.State.ToBool();
                if (string.IsNullOrEmpty(tags))
                    throw new Exception("块标签不能为空！");
                bool verifyTags = IsExists(m => m.SystemID == systemId && m.CompanyID == companyId && m.Tags == tags);
                if (verifyTags)
                    throw new Exception("块标签不能重复！");
                entity.BlockID = blockId;
                entity.State = state;
                entity.CreateDate = DateTime.Now;
                return Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateBlock(Info_Block entity)
        {
            try
            {
                int systemId = entity.SystemID;
                string companyId = entity.CompanyID;
                string blockId = entity.BlockID;
                string tags = entity.Tags;
                bool state = entity.State.ToBool();
                if (string.IsNullOrEmpty(tags))
                    throw new Exception("块标签不能为空！");
                bool verifyTags = IsExists(m => m.SystemID == systemId && m.CompanyID == companyId && m.BlockID != blockId && m.Tags == tags);
                if (verifyTags)
                    throw new Exception("块标签不能重复！");
                return Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateBlockState(int systemId, string companyId, string blockId, bool state)
        {
            try
            {
                try
                {
                    var entity = Find(m => m.SystemID == systemId && m.CompanyID == companyId && m.BlockID == blockId);
                    entity.State = state;
                    return Update(entity);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteBlock(int systemId, string companyId, string blockId)
        {
            try
            {
                return Delete(m => m.SystemID == systemId && m.CompanyID == companyId && m.BlockID == blockId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Info_Block GetBlock(int systemId, string companyId, string blockId)
        {
            try
            {
                return Find(m => m.SystemID == systemId && m.CompanyID == companyId && m.BlockID == blockId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Info_Block GetBlock(int systemId, string companyId, string tags, string state)
        {
            try
            {
                bool noticeState = state.ToBool();
                var expression = ExtLinq.True<Info_Block>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId && m.Tags == tags
                && (string.IsNullOrWhiteSpace(state) ? m.State.Value.Equals(m.State) : m.State.Value == noticeState));
                return Find(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Block> GetBlockAll(int systemId, string companyId, string state)
        {
            try
            {
                bool verifyState = state.ToBool();
                var expression = ExtLinq.True<Info_Block>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && (string.IsNullOrWhiteSpace(state) ? m.State.Value.Equals(m.State) : m.State.Value == verifyState));
                return FindList(expression, m => m.CreateDate, false).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Block> GetBlockPaging(int systemId, string companyId, int pageId, int pageSize)
        {
            try
            {
                var expression = ExtLinq.True<Info_Block>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId);
                int pageIndex = Utility.ToPageIndex(pageId);
                int pageCount = Utility.ToPageCount(pageSize);
                return FindListPaging(expression, m => m.CreateDate, false, pageIndex, pageCount).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Info_Block> SearchBlock(int systemId, string companyId, string startTime, string endTime, string state, string keyword, int count)
        {
            try
            {
                DateTime dateStartTime = Utility.ToStartTime(startTime);
                DateTime dateEndTime = Utility.ToEndTime(endTime);
                bool blnState = state.ToBool();
                int total = count;
                //条件
                var expression = ExtLinq.True<Info_Block>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && m.CreateDate.Value.Date >= dateStartTime.Date && m.CreateDate.Value.Date <= dateEndTime.Date
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == blnState)
                && (m.Title.Contains(keyword) || m.Tags.Contains(keyword)));
                //执行
                return FindListTop(expression, m => m.CreateDate, false, total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long CountBlock(int systemId, string companyId)
        {
            try
            {
                var expression = ExtLinq.True<Info_Block>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId);
                return Count(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long CountBlock(int systemId, string companyId, string startTime, string endTime, string state, string keyword)
        {
            try
            {
                DateTime dateStartTime = Utility.ToStartTime(startTime);
                DateTime dateEndTime = Utility.ToEndTime(endTime);
                bool blnState = state.ToBool();
                var expression = ExtLinq.True<Info_Block>();
                expression = expression.And(m => m.SystemID == systemId && m.CompanyID == companyId
                && m.CreateDate.Value.Date >= dateStartTime.Date && m.CreateDate.Value.Date <= dateEndTime.Date
                && (string.IsNullOrWhiteSpace(state) ? true : m.State.Value == blnState)
                && (m.Title.Contains(keyword) || m.Tags.Contains(keyword)));
                return Count(expression);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
