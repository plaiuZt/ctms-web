using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.DAL.Institution
{
    using CTMS.DbContexts;
    using CTMS.DbModels;
    using CTMS.DbStoredProcedure;
    using CTMS.IDAL.Institution;
    public partial class PositionDAL:BaseDAL<Institution_Position>,IPositionDAL
    {
        public PositionDAL(CTMSContext dbContext) : base(dbContext)
        {
        }
    }
}
