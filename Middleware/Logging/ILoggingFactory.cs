using System;

namespace Middleware
{
    /// <summary>
    /// ��־����
    /// </summary>
    public interface ILoggingFactory {
        /// <summary>
        /// ������־��
        /// </summary>
        /// <returns></returns>
        ILogging CreateLogger();
    }
}