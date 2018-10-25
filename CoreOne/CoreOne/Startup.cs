using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Core.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using One.Core.DAL;
using One.Core.Interface;

namespace CoreOne
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //连接数据库
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EntryContext>(options => options.UseSqlServer(connection));
            //services.AddScoped<IUnitOfWork, UnitOfWork>();//注入工作单元
            //ContainerBuilder containerBuilder = new ContainerBuilder();
            //containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            ////containerBuilder.RegisterController
            //var container = containerBuilder.Build();
        }


        /// <summary>
        /// 用于指定应用响应 HTTP 请求的方式
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.ApplicationServices.GetRequiredService() //获取服务类

            #region 设置静态文件目录
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "ddd")),
            //    RequestPath = "/StaticFiles" //访问的路径
            //});
            //< img src = "~/StaticFiles/images/banner1.svg" alt = "ASP.NET" class="img-responsive" />
            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            //var trackPackageRouteHandler = new RouteHandler(context =>
            //{
            //    var routeValues = context.GetRouteData().Values;
            //    return context.Response.WriteAsync(
            //        $"Hello! Route values: {string.Join(", ", routeValues)}");
            //});

            //var routeBuilder = new RouteBuilder(app, trackPackageRouteHandler);

            //routeBuilder.MapRoute(
            //    name: "default",
            //    template: "{controller=Values}/{action=Get}"
            //    );
            //var routes = routeBuilder.Build();
            //app.UseRouter(routes);

            app.UseHttpsRedirection();
            //app.UseMvc();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action}/");//无默认
            //});
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "api/{controller=User}/{action=Get}");//默认 没啥用
            });
        }
    }
}
