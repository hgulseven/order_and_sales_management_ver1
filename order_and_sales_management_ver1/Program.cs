using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace order_and_sales_management_ver1
{
    public class logger
    {
        public void write_to_log(string functionName, string err)
        {
            StreamWriter logWriter=null;

            FileInfo logFile = new FileInfo("error_log.txt");
            if (logFile.Exists)
            {
                if (logFile.Length > 250)
                {
                    logFile.Replace("error_log_old.txt", null, false);
                    logWriter = logFile.CreateText();
                } else
                {
                    logWriter=logFile.AppendText();
                }
            } else
            {
                logWriter = logFile.CreateText();
                logFile.CopyTo("error_log_old.txt");
            }
            String logLine=string.Format("{0:27} Function : {1,-25}  Err: {2,-255}\n", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fffff"), functionName, err);
            logWriter.Write(logLine);
            logWriter.Close();
        }
    }
    public class Program
    {
        public const int Const_Production_Location = 1;

        public const int Const_Active_Order = 1;
        public const int Const_Order_Loaded = 2;
        public const int Const_Order_Partially_Loaded = 3;
        public const int Const_Order_Delivered = 4;
        public const int Const_Order_Partially_Delivered = 5;
        public const int Const_Order_Deleted = 6;
        public const int Const_Order_Not_Accepted = 7;
        public static DateTime Const_Valid_To_Date { get; set; }

        public const int Const_Record_Active = 1;
        public const int Const_Record_Deleted=-1;
        public static string Connection_String;

        public static void Main(string[] args)
        {
            Const_Valid_To_Date = DateTime.Parse("2099-01-01");
            CreateWebHostBuilder(args).Build().Run();

        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>();

        /*ç
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseIISIntegration()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory());
*/
    }
}
