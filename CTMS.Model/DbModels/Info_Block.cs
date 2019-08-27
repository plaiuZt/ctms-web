using System;
using System.Collections.Generic;

namespace CTMS.DbModels
{
    public partial class Info_Block
    {
        public int SystemID { get; set; }
        public string CompanyID { get; set; }
        public string BlockID { get; set; }
        public string Title { get; set; }
        public string Tags { get; set; }
        public string Remark { get; set; }
        public string Content { get; set; }
        public bool? State { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
