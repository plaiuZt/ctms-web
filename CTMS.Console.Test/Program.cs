using System;
using System.Diagnostics;

namespace CTMS.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                IFreeSql Fsql = new FreeSql.FreeSqlBuilder()
                        .UseConnectionString(FreeSql.DataType.SqlServer, @"Server=WIN-TONY\SQLEXPRESS;User Id=sa;Password=123456;Database=LdCms_Db")
                        .UseAutoSyncStructure(false)
                        .UseNoneCommandParameter(true)
                        .UseMonitorCommand(cmd => Trace.WriteLine(cmd.CommandText))
                        .Build();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            
        }
    }
}
