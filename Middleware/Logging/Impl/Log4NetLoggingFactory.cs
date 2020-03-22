

namespace Middleware
{
    public class Log4NetLoggingFactory : ILoggingFactory
    {
        public ILogging CreateLogger()
        {
            return Log4NetLogging.Instance;
        }
    }
}