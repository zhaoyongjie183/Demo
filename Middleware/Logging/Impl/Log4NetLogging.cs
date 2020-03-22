using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Microsoft.Extensions.Hosting;

namespace Middleware
{
    public class Log4NetLogging : ILogging
    {
        private static readonly ILogging _instance = new Log4NetLogging();
        private static IServiceProvider _ServiceProvider;
        private static ILog _Logger; 

        public Log4NetLogging()
        {
            ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
            var conf = "Log4Net.config";
            var dir = _ServiceProvider.GetService<IHostEnvironment>().ContentRootPath;
            if (!string.IsNullOrEmpty(dir))
            {
                conf = dir + "/" + conf;
            }
            XmlConfigurator.Configure(repository, new FileInfo(conf));
            _Logger = LogManager.GetLogger(repository.Name, "NETCorelog4net");
        }

        public static ILogging Instance
        {
            get { return _instance; }
        }

        public bool IsEnabled(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Information:
                    return _Logger.IsInfoEnabled;
                case LogLevel.Warning:
                    return _Logger.IsWarnEnabled;
                case LogLevel.Debug:
                    return _Logger.IsDebugEnabled;
                case LogLevel.Error:
                    return _Logger.IsErrorEnabled;
                case LogLevel.Fatal:
                    return _Logger.IsFatalEnabled;
                default: return false;
            }
        }

        public void Log(LogLevel level, Exception exception, string format, params object[] args)
        {
            switch (level)
            {
                case LogLevel.Information:
                    _Logger.Info(args == null ? format : string.Format(format, args), exception);
                    break;
                case LogLevel.Warning:
                    _Logger.Warn(args == null ? format : string.Format(format, args), exception);
                    break;
                case LogLevel.Debug:
                    _Logger.Debug(args == null ? format : string.Format(format, args), exception);
                    break;
                case LogLevel.Error:
                    _Logger.Error(args == null ? format : string.Format(format, args), exception);
                    break;
                case LogLevel.Fatal:
                    _Logger.Fatal(args == null ? format : string.Format(format, args), exception);
                    break;
            }
        }
    }
}