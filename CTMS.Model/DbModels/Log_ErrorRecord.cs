﻿using System;
using System.Collections.Generic;

namespace CTMS.DbModels
{
    public partial class Log_ErrorRecord
    {
        public long ID { get; set; }
        public int? SystemID { get; set; }
        public byte? ClientID { get; set; }
        public string Url { get; set; }
        public string Message { get; set; }
        public string IpAddress { get; set; }
        public bool? State { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
