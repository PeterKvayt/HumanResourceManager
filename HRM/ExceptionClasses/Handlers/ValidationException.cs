using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionClasses.Handlers
{
    class ValidationException : Exception
    {
        public string Property { get; protected set; }

        public ValidationException(string message, string property) : base(message)
        {
            Property = property;
        }
    }
}
