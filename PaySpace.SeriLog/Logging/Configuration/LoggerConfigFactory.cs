using System;
using System.Configuration;
using PaySpace.Logging.Logging.Interfaces;

namespace PaySpace.Logging.Logging.Configuration
{
    public class LoggerConfigFactory : ILoggerConfigFactory
    {
        public ILoggerConfig GetLoggerConfig()
        {
            var loggingConfig = ConfigurationManager.GetSection("loggingConfig") as LoggerConfig ?? new LoggerConfig();

            return loggingConfig;
        }

        private static string GetApplication()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                var result = appSettings["Application"];
                return result;
            }
            catch (Exception)
            {
                return "Unspecified";
            }
        }

        private static string GetEnvironment()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                var result = appSettings["Environment"];
                return result;
            }
            catch (Exception)
            {
                return "Unspecified";
            }
        }
    }
}
