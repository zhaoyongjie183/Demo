using System;

namespace Middleware
{
    /// <summary>
    /// 日志工厂
    /// </summary>
    public interface ILoggingFactory {
        /// <summary>
        /// 创建日志类
        /// </summary>
        /// <returns></returns>
        ILogging CreateLogger();
    }
}