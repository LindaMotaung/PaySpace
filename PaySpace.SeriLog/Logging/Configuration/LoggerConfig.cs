using System.Configuration;
using PaySpace.Logging.Logging.Interfaces;

namespace PaySpace.Logging.Logging.Configuration
{
    public class LoggerConfig : ConfigurationSection, ILoggerConfig
    {
        [ConfigurationProperty("debugConfig")]
        private LoggerDebugConfig _debugConfig => base["debugConfig"] as LoggerDebugConfig;

        public ILoggerDebugConfig DebugConfig => _debugConfig;
    }
}
