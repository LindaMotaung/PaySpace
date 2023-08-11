using System;

namespace PaySpace.Logging.Logging.Common
{
    public interface ILogger : IDisposable
    {
        void Log(LoggingLevel level, string messageTemplate, params object[] propertyValues);
        void Log(LoggingLevel level, Exception exception, string messageTemplate, params object[] propertyValues);
    }
}
