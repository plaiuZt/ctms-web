﻿using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;

namespace CTMS.DbModels
{
    public partial class Log_LoginRecord
    {
        [Column(IsIdentity = true)]
        public long ID { get; set; }
        public int? SystemID { get; set; }
        public string CompanyID { get; set; }
        public byte? ClientID { get; set; }
        public string ClientName { get; set; }
        public byte? TypeID { get; set; }
        public string TypeName { get; set; }
        public string Account { get; set; }
        public string NickName { get; set; }
        public string IpAddress { get; set; }
        public bool? IsResult { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
