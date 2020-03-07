using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionClasses.Interfaces
{
    public interface IException
    {
        string ExceptionMessage { get; set; }

        void Throw();
    }
}
