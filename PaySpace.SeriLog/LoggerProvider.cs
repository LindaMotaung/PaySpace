using PaySpace.Logging;
using PaySpace.Logging.Logging.Common;
using PaySpace.Logging.Logging.Configuration;

namespace PaySpace.SeriLog
{
    public class LoggerProvider
    {
        public static ILogger Log = new SerilogAdapter(new LoggerConfigFactory());
    }
}
