using System;
using System.Collections.Generic;

namespace CTMS.DbModels
{
    public partial class Sys_Code
    {
        public int SystemID { get; set; }
        public string SystemName { get; set; }
        public string Description { get; set; }
        public bool? State { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
