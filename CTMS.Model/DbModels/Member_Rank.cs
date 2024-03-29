﻿using System;
using System.Collections.Generic;

namespace CTMS.DbModels
{
    public partial class Member_Rank
    {
        public int SystemID { get; set; }
        public string CompanyID { get; set; }
        public string RankID { get; set; }
        public string RankName { get; set; }
        public int? MinPoints { get; set; }
        public int? MaxPoints { get; set; }
        public int? Discount { get; set; }
        public int? ShowPrice { get; set; }
        public int? SpecialRank { get; set; }
        public string Remark { get; set; }
        public bool? State { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
