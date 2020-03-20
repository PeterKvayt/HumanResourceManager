using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExceptionClasses.Loggers
{
    public static class ExceptionLogger
    {
        /// <summary>
        /// Путь к файлу, в котором хранятся логи
        /// </summary>
        private static readonly string pathToLogDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

        /// <summary>
        /// Создает директорию, в которой будут храниться логи
        /// </summary>
        private static void CreateLogDirectory()
        {
            if ( !Directory.Exists(pathToLogDirectory) )
            {
                Directory.CreateDirectory(pathToLogDirectory);
            }
        }

        /// <summary>
        /// Создает путь к файлу для хранения лога
        /// </summary>
        /// <returns>Путь к файлу хранения лога</returns>
        private static string GetLogFileName()
        {
            CreateLogDirectory();

            return string.Format($"{AppDomain.CurrentDomain.FriendlyName}_{DateTime.Now:dd.MM.yyy}.log");
        }

        /// <summary>
        /// Возвращает путь к файлу хранения лога
        /// </summary>
        /// <returns>Путь к файлу</returns>
        private static string GetPathToLogFile()
        {
            string logFileName = GetLogFileName();

            return Path.Combine(pathToLogDirectory, logFileName);
        }

        /// <summary>
        /// Логирует сообщение об исключении 
        /// </summary>
        /// <param name="exception">Исключение</param>
        public static void Log(Exception exception)
        {
            string logMessage = string.Format($"[{DateTime.Now:dd.MM.yyy HH:mm:ss.fff}] Ошибка в методе [{exception.TargetSite.DeclaringType}.{exception.TargetSite.Name}](): {exception.Message}\r\n");

            WriteToFile(logMessage);
        }

        /// <summary>
        /// Логирует сообщение об исключении
        /// </summary>
        /// <param name="message">Сообщение об исключении</param>
        /// <param name="exceptedClass">Класс, в котором произошло исключение</param>
        /// <param name="exceptedMethod">Метод, в котором произошло исключение</param>
        public static void Log(string message, string exceptedClass, string exceptedMethod)
        {
            string logMessage = string.Format($"[{DateTime.Now:dd.MM.yyy HH:mm:ss.fff}] Ошибка в методе [{exceptedClass}.{exceptedMethod}()]: {message}\r\n");

            WriteToFile(logMessage);
        }

        /// <summary>
        /// Записывает в файл логи
        /// </summary>
        /// <param name="logMessage">Сообщение, которое необходимо залогировать</param>
        private static void WriteToFile(string logMessage)
        {
            string path = GetPathToLogFile();

            object locker = new object();

            lock (locker)
            {
                File.AppendAllText(path, logMessage);
            }
        }
    }
}
