using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Institution
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IDAL.Institution;
    /// <summary>
    /// 
    /// </summary>
    public partial class StaffDAL:BaseDAL<Institution_Staff>,IStaffDAL
    {
        public StaffDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
