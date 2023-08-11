
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PaySpace.DataLayer.Interfaces.Core.Logger;
using PaySpace.Logging.Logging;
using PaySpace.Logging.Logging.Models;
using ILogger = PaySpace.Logging.Logging.Common.ILogger;

namespace PaySpace.DataLayer.Core.Logger
{
    public class DbContextLogger : IDbContextLogger
    {
        private const int COMMAND_EXECUTED = 20101;

        private readonly ILogger _logger;

        public DbContextLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                    _logger.Verbose(formatter(state, exception));
                    break;
                case LogLevel.Debug:
                    _logger.Debug(formatter(state, exception));
                    break;
                case LogLevel.Information:
                    LogInformation(eventId, state, exception, formatter);
                    break;
                case LogLevel.Warning:
                    _logger.Warning(formatter(state, exception));
                    break;
                case LogLevel.Error:
                    _logger.Error(formatter(state, exception));
                    break;
                case LogLevel.Critical:
                    _logger.Error(formatter(state, exception));
                    break;
                case LogLevel.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // We rather make use of serilog logging level config
            // so we don't filter out any log levels at this point
            //return true;

            // For performance reasons we only log from information
            // level and higher for now
            return logLevel >= LogLevel.Information;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            var s = state as IDisposable;
            return s;
        }

        private void LogInformation<TState>(EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (eventId == COMMAND_EXECUTED)
            {
                if (state is IReadOnlyList<KeyValuePair<string, object>> keyList)
                {
                    try
                    {
                        var commandTextKeyValue = keyList.FirstOrDefault(x => x.Key == "commandText");
                        var elapsedKeyValue = keyList.FirstOrDefault(x => x.Key == "elapsed");
                        var commandTypeKeyValue = keyList.FirstOrDefault(x => x.Key == "commandType");

                        var commandText = (string)commandTextKeyValue.Value;
                        var elapsed = double.Parse((string)elapsedKeyValue.Value);
                        var commandType = ((CommandType)commandTypeKeyValue.Value).ToString();

                        LogExecution(commandText, elapsed, commandType);
                        return;
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex);
                    }
                }
            }

            _logger.Information(formatter(state, exception));
        }

        private void LogExecution(string commandText, double durationMs, string method)
        {
            _logger.Information("DataLayer execution {@transactionModel}",
                new CommandExecuteLog
                {
                    CommandText = commandText,
                    DurationMs = durationMs,
                    Method = method
                });
        }
    }
}
