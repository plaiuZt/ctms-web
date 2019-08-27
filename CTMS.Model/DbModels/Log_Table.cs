using System;
using System.Collections.Generic;

namespace CTMS.DbModels
{
    public partial class Log_Table
    {
        public string TableID { get; set; }
        public string TableName { get; set; }
        public string BusinessName { get; set; }
        public string PrimaryKey { get; set; }
        public string UrlTemplate { get; set; }
        public string Account { get; set; }
        public string NickName { get; set; }
        public string Remark { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
