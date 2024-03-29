﻿using System;
using System.Collections.Generic;

namespace CTMS.DbModels
{
    public partial class Member_RefreshToken
    {
        public string RefreshToken { get; set; }
        public string Token { get; set; }
        public int? ExpiresIn { get; set; }
        public string IpAddress { get; set; }
        public int? CreateTimestamp { get; set; }
        public bool? State { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
