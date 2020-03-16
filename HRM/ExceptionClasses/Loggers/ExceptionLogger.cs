using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExceptionClasses.Loggers
{
    public static class ExceptionLogger
    {
        private static readonly object _locker = new object();

        private static readonly string pathToLogDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

        private static void CreateLogDirectory()
        {
            if ( !Directory.Exists(pathToLogDirectory) )
            {
                Directory.CreateDirectory(pathToLogDirectory);
            }
        }

        private static string GetLogFileName()
        {
            CreateLogDirectory();

            return string.Format($"{AppDomain.CurrentDomain.FriendlyName}_{DateTime.Now:dd.MM.yyy}.log");
        }

        private static string GetPathToLogFile()
        {
            string logFileName = GetLogFileName();

            return Path.Combine(pathToLogDirectory, logFileName);
        }

        public static void Log(Exception exception)
        {
            string logMessage = string.Format($"[{DateTime.Now:dd.MM.yyy HH:mm:ss.fff}] Ошибка в методе [{exception.TargetSite.DeclaringType}.{exception.TargetSite.Name}](): {exception.Message}\r\n");

            WriteToFile(logMessage);
        }

        public static void Log(string message, string exceptedClass, string exceptedMethod)
        {
            string logMessage = string.Format($"[{DateTime.Now:dd.MM.yyy HH:mm:ss.fff}] Ошибка в методе [{exceptedClass}.{exceptedMethod}()]: {message}\r\n");

            WriteToFile(logMessage);
        }

        private static void WriteToFile(string logMessage)
        {
           string path = GetPathToLogFile();

            lock (_locker)
            {
                File.AppendAllText(path, logMessage);
            }
        }

        // leave
        public static void LogError(string c)
        {

        }

        //leave
        public static void LogWarn(string c)
        {

        }
    }
}
