using System;
using System.Collections.Generic;

namespace CTMS.DbModels
{
    public partial class Sys_AccessCorsHost
    {
        public int SystemID { get; set; }
        public string WebHost { get; set; }
        public string Remark { get; set; }
        public string Account { get; set; }
        public string NickName { get; set; }
        public bool? State { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
