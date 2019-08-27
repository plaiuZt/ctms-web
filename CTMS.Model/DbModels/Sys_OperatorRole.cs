using System;
using System.Collections.Generic;

namespace CTMS.DbModels
{
    public partial class Sys_OperatorRole
    {
        public int SystemID { get; set; }
        public string CompanyID { get; set; }
        public string StaffID { get; set; }
        public string RoleID { get; set; }
    }
}
