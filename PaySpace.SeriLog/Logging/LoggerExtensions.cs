using System;
using PaySpace.Logging.Logging.Common;

namespace PaySpace.Logging.Logging
{
    public static class LoggerExtensions
    {
        public static void Information(this ILogger logger, string messageTemplate, params object[] propertyValues)
        {
            logger.Log(LoggingLevel.Information, messageTemplate, propertyValues);
        }

        public static void Debug(this ILogger logger, string messageTemplate, params object[] propertyValues)
        {
            logger.Log(LoggingLevel.Debug, messageTemplate, propertyValues);
        }

        public static void Debug(this ILogger logger, Exception exception, string messageTemplate,
            params object[] propertyValues)
        {
            logger.Log(LoggingLevel.Debug, exception, messageTemplate, propertyValues);
        }

        public static void Verbose(this ILogger logger, string messageTemplate, params object[] propertyValues)
        {
            logger.Log(LoggingLevel.Verbose, messageTemplate, propertyValues);
        }

        public static void Verbose(this ILogger logger, Exception exception)
        {
            logger.Log(LoggingLevel.Verbose, exception, exception.Message);
        }

        public static void Warning(this ILogger logger, string messageTemplate, params object[] propertyValues)
        {
            logger.Log(LoggingLevel.Warning, messageTemplate, propertyValues);
        }

        public static void Warning(this ILogger logger, Exception exception)
        {
            logger.Log(LoggingLevel.Warning, exception, exception.Message);
        }

        public static void Warning(this ILogger logger, Exception exception, string messageTemplate,
            params object[] propertyValues)
        {
            logger.Log(LoggingLevel.Warning, exception, messageTemplate, propertyValues);
        }

        public static void Error(this ILogger logger, string messageTemplate, params object[] propertyValues)
        {
            logger.Log(LoggingLevel.Error, messageTemplate, propertyValues);
        }

        public static void Error(this ILogger logger, Exception exception)
        {
            logger.Log(LoggingLevel.Error, exception, exception.Message);
        }

        public static void Error(this ILogger logger, Exception exception, string messageTemplate,
            params object[] propertyValues)
        {
            logger.Log(LoggingLevel.Error, exception, messageTemplate, propertyValues);
        }
    }
}
