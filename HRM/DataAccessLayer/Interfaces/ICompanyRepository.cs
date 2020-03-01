using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    interface ICompanyRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Возвращает размер компании
        /// </summary>
        /// <param name="item">Компания</param>
        /// <returns>Размер компании</returns>
        int GetSize(T item);
    }
}
