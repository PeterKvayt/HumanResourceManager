using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionClasses.Exceptions
{
    abstract class GeneralException<TException> : Exception where TException : Exception, new()
    {
        public string ExceptionMessage { get; set; }

        public virtual void Throw()
        {
            throw new TException();
        }
    }
}
