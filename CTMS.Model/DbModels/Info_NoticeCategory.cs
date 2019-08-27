using System;
using System.Collections.Generic;

namespace CTMS.DbModels
{
    public partial class Info_NoticeCategory
    {
        public int SystemID { get; set; }
        public string CompanyID { get; set; }
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Remark { get; set; }
        public int? Sort { get; set; }
        public bool? State { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
