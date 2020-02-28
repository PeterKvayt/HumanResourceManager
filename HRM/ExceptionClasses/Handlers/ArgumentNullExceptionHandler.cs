using ExceptionClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionClasses.Handlers
{
    public class ArgumentNullExceptionHandler : GeneralExceptionHandler, IExceptionHandler
    {
        public ArgumentNullExceptionHandler(string message) : base(message) { }

        public void ThrowException()
        {
            _logger.Error(_message);

            throw new ArgumentNullException();
        }
    }
}
