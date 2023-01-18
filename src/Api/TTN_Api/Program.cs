using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace TTN_DDOI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var fleContent = File.ReadAllText("C:\\Users\\Usman\\Downloads\\ttn_cp1_202106151.log");
            //var reqSplit = fleContent.Split(new string[] { "Request: " }, StringSplitOptions.None);
            //var reqSplit2 = fleContent.Split(new string[] { "Request1: " }, StringSplitOptions.None);
            //Console.WriteLine(reqSplit.Length);
            //Console.WriteLine(reqSplit.Length);
            //foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
            //{
            //    Console.WriteLine(z.Id);
            //}
         
            var config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();
            //Initialize Logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();
            Log.Information("Application Starting.");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog();
    }
}
