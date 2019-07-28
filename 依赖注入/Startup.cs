using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using 依赖注入.Interface;
using 依赖注入.Service;

namespace 依赖注入
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _config;
        private readonly ILoggerFactory _loggerFactory;
        public Startup(IHostingEnvironment env, IConfiguration config,
        ILoggerFactory loggerFactory)
        {
            _env = env;
            _config = config;
            _loggerFactory = loggerFactory;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Bar>(p=> { return new Bar(); });
            services.AddSingleton<Bar>();
            services.AddSingleton<IBar, Bar>();
            services.AddSingleton(typeof(IBar),typeof(Bar));
            services.AddSingleton(typeof(IConfiguration), _config);



            //日志使用  内置日志无法输出到文件  使用第三方日志插件NLOG
            //var logger = _loggerFactory.CreateLogger<Startup>();
     
            //if (_env.IsDevelopment())
            //{
            //    // Development service configuration

            //    logger.LogInformation("Development environment");
            //    logger.LogDebug("asdasdasdasdas");
            //}
            //else
            //{
            //    // Non-development service configuration

            //    logger.LogInformation($"Environment: {_env.EnvironmentName}");
            //}
        }
      

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
