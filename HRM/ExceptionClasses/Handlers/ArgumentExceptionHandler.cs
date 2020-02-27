using ExceptionClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionClasses.Handlers
{
    public class ArgumentExceptionHandler : GeneralExceptionHandler, IExceptionHandler
    {
        public ArgumentExceptionHandler(string message) : base(message) { }

        public void ThrowException()
        {
            _logger.Error(_message);

            throw new ArgumentException();
        }
    }
}
