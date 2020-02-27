using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionClasses.Interfaces
{
    public interface IExceptionHandler
    {
        /// <summary>
        /// Логирует исключение и пробрасывает его вверх по стеку вызова
        /// </summary>
        void ThrowException();
    }
}
