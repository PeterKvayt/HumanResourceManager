using ExceptionClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionClasses.Exceptions
{
    public class ServerException : GeneralException<ClientException>, IException
    {
        public ServerException() { }

        public ServerException(string message)
        {
            ExceptionMessage = message;
        }
    }
}
