using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoreOne
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            //.ConfigureAppConfiguration((hostingContext,builder)=>{
            //    builder.SetBasePath(Directory.GetCurrentDirectory());
            //    builder.AddIniFile("config.file", optional: true, reloadOnChange:true);
            //})//添加配置文件
            //.UseKestrel(option =>
            //{

            //})
            .ConfigureServices(services =>
            {
                //server
            }).Configure(app =>
            {
                //app
            })
                .UseStartup<Startup>();
    }
}
