﻿using System;
using System.Collections.Generic;

namespace CTMS.DbModels
{
    public partial class Sys_InterfaceAccount
    {
        public int SystemID { get; set; }
        public string CompanyID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Uuid { get; set; }
        public string AppID { get; set; }
        public string AppSecret { get; set; }
        public string AppKey { get; set; }
        public bool? IsWcf { get; set; }
        public bool? IsWeb { get; set; }
        public bool? IsApi { get; set; }
        public bool? IsCors { get; set; }
        public int? RequestTotalNumber { get; set; }
        public string Description { get; set; }
        public bool? State { get; set; }
        public bool? IsDel { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
