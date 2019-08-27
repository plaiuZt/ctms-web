using System;
using System.Collections.Generic;

namespace CTMS.DbModels
{
    public partial class Sys_RoleFunction
    {
        public int SystemID { get; set; }
        public string CompanyID { get; set; }
        public string RoleID { get; set; }
        public string FunctionID { get; set; }
    }
}
