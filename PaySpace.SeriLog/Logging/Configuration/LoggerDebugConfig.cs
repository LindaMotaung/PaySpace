using System.Configuration;
using PaySpace.Logging.Logging.Interfaces;

namespace PaySpace.Logging.Logging.Configuration
{
    public class LoggerDebugConfig : KeyValueConfigurationCollection, ILoggerDebugConfig
    {
        public bool IsEnabled
        {
            get
            {
                var element = this["debug:isEnabled"];
                return element is {Value: { }} && bool.Parse(element.Value);
            }
        }
    }
}
