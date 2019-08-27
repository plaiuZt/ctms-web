using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Extend
{
    using CTMS.DbModels;
    using CTMS.DbContexts;
    using CTMS.IDAL.Extend;
    /// <summary>
    /// 
    /// </summary>
    public partial class SearchKeywordDAL:BaseDAL<Extend_SearchKeyword>,ISearchKeywordDAL
    {
        public SearchKeywordDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
