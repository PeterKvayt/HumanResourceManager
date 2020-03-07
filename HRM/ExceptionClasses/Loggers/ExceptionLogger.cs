using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionClasses.Loggers
{
    public static class ExceptionLogger
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static void LogDebug(string message)
        {
            _logger.Debug(message);
        }

        public static void LogError(string message)
        {
            _logger.Error(message);
        }

        public static void LogFatal(string message)
        {
            _logger.Fatal(message);
        }

        public static void LogInfo(string message)
        {
            _logger.Info(message);
        }

        public static void LogTrace(string message)
        {
            _logger.Trace(message);
        }

        public static void LogWarn(string message)
        {
            _logger.Warn(message);
        }
    }
}
