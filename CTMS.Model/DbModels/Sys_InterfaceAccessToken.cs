﻿using System;
using System.Collections.Generic;

namespace CTMS.DbModels
{
    public partial class Sys_InterfaceAccessToken
    {
        public string Token { get; set; }
        public int SystemID { get; set; }
        public string CompanyID { get; set; }
        public string AppID { get; set; }
        public int? ExpiresIn { get; set; }
        public string IpAddress { get; set; }
        public int? CreateTimestamp { get; set; }
        public bool? State { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
