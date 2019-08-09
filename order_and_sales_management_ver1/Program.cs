using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace order_and_sales_management_ver1
{
    public class Program
    {
        public const int Const_Production_Location = 1;

        public const int Const_Active_Order = 1;
        public const int Const_Order_Delivered = 2;
        public const int Const_Order_Deleted = 3;
        public const int Const_Order_Not_Accepted = 4;

        public const int Const_Record_Active = 1;
        public const int Const_Record_Deleted=-1;
        public static string Connection_String;

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseIISIntegration()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory());
    }
}
