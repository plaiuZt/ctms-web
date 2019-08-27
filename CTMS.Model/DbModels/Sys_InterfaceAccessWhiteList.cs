﻿using System;
using System.Collections.Generic;

namespace CTMS.DbModels
{
    public partial class Sys_InterfaceAccessWhiteList
    {
        public int SystemID { get; set; }
        public string CompanyID { get; set; }
        public string Account { get; set; }
        public string IpAddress { get; set; }
        public byte ClassID { get; set; }
        public string ClassName { get; set; }
        public string Remark { get; set; }
        public bool? State { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
