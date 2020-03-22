using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Middleware
{
    public class Startup
    {
        /// <summary>
        /// ʹ��log4net��Ҫȥ�������ļ���configuration�ڵ�
        /// </summary>
        //public static ILoggerRepository repository { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //var conf = "Log4Net.config";
            //repository = LogManager.CreateRepository("NetCoreRepository");
            //XmlConfigurator.Configure(repository, new FileInfo(conf));
   
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<ILoggingFactory, Log4NetLoggingFactory>();

            //��Ҫ����nuget����Microsoft.AspNetCore.Mvc.NewtonsoftJson
            services.AddMvc().AddNewtonsoftJson(jsonOptions => {

                jsonOptions.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });

            //���÷��ظ�ʽ
            //services.AddControllers().AddNewtonsoftJson(jsonOptions => {

            //    jsonOptions.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            //});
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseExceptionHandler("/api/error");
            app.UseExceptionHandlerMiddlewareExtensions();

            app.Use(async (context, next) =>
            {
                Console.WriteLine("��������");

                await next.Invoke();

                Console.WriteLine("�ǺǺǺ�"+ context.Request.Path);
                // Do logging or other work that doesn't write to the Response.
            });

            //loggerFactory.AddLog4Net();

            //loggerFactory.CreateLogger<Program>().LogError("test");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
          

            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("��������1");

            //    await next.Invoke();
            //    // Do logging or other work that doesn't write to the Response.
            //});


        }
    }
}
