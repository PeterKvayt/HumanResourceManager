using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionClasses.Handlers
{
    public abstract class GeneralExceptionHandler
    {
        protected Logger _logger = LogManager.GetCurrentClassLogger();

        protected readonly string _message;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public GeneralExceptionHandler(string message)
        {
            _message = message;
        }
    }
}
