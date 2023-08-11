using System;
using System.Diagnostics;
using PaySpace.Logging.Logging.Interfaces;
using Serilog;
using Serilog.Debugging;
using Serilog.Events;
using Serilog.Exceptions;
using ILogger = PaySpace.Logging.Logging.Common.ILogger;

namespace PaySpace.Logging
{
    public class SerilogAdapter : ILogger
    {
        private Serilog.ILogger logger;

        public SerilogAdapter(ILoggerConfigFactory configFactory)
        {
            if (configFactory == null) throw new ArgumentNullException(nameof(configFactory));
            InitiateLogger(configFactory);
        }

        public void Log(LoggingLevel level, string messageTemplate, params object[] propertyValues)
        {
            logger.Write((LogEventLevel)level, messageTemplate, propertyValues);
        }

        public void Log(LoggingLevel level, Exception exception, string messageTemplate, params object[] propertyValues)
        {
            logger.Write((LogEventLevel)level, exception, messageTemplate, propertyValues);
        }

        public void Dispose()
        {
            if (logger is IDisposable log) log.Dispose();
        }

        private void InitiateLogger(ILoggerConfigFactory loggerConfigFactory)
        {
            var configuration = loggerConfigFactory.GetLoggerConfig();
            var log = GetLoggerConfiguration();
            ConfigureDebugSink(log, configuration);

            logger = log.CreateLogger();
        }

        private static LoggerConfiguration GetLoggerConfiguration()
        {
            return new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .Enrich.FromLogContext()
                /*.Enrich.WithMemoryUsage()
                .Enrich.WithExceptionDetails()
                .Enrich.WithHttpRequestType()
                .Enrich.WithHttpRequestId()
                .Enrich.WithHttpSessionId()
                .Enrich.WithHttpRequestClientHostIP()
                .Enrich.WithHttpRequestUserAgent()
                .Enrich.WithHttpRequestUrl()
                .Enrich.WithHttpRequestUrlReferrer()
                .Enrich.WithMachineName()
                .Enrich.WithCatUserName()*/;
        }

        private static void ConfigureDebugSink(LoggerConfiguration log, ILoggerConfig configuration)
        {
            var debugConfig = configuration.DebugConfig;

            // Check if debugging is enabled in the web config
            if (!debugConfig.IsEnabled) return;

            SelfLog.Enable(msg =>
            {
                // The following logs internal serilog messages to the debug console
                Debug.WriteLine(msg);
            });

            // Enable logging to the debug console as a sink
            log.WriteTo.Debug();
        }
    }
}
