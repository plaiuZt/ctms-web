using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Web
{
    public partial interface ITableOperationManager<T> where T : new()
    {
        string PrimaryKey { get; set; }
        string Account { get; set; }
        string NickName { get; set; }
        bool Select(T t, out long operationId);
        bool Add(T t, out long operationId);
        bool Add(T t, bool state);
        bool Update(T t, string newContent, out long operationId);
        bool Update(T t, string newContent, bool state);
        bool Delete(T t, out long operationId);
        bool Delete(T t, bool state);
        bool SetState(long id, bool state);
    }
}
