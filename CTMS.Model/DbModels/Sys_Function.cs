﻿using System;
using System.Collections.Generic;

namespace CTMS.DbModels
{
    public partial class Sys_Function
    {
        public string FunctionID { get; set; }
        public string FunctionName { get; set; }
        public string ParentID { get; set; }
        public int? RankID { get; set; }
        public bool? Selected { get; set; }
        public bool? State { get; set; }
        public bool? IsDel { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
