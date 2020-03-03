using CommonClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    public interface IService<T>
    {
        /// <summary>
        /// Возвращает все объекты 
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Возвращает объект, соответствующий параметру id 
        /// </summary>
        /// <param name="id">Параметр, по которому ведется поиск</param>
        /// <returns></returns>
        T Get(IdType id);

        /// <summary>
        /// Создает объект в базе данных
        /// </summary>
        /// <param name="item"></param>
        void Create(T item);

        /// <summary>
        /// Обновляет объект в базе данных 
        /// </summary>
        /// <param name="item">Обновляемый объект</param>
        void Update(T item);

        /// <summary>
        /// Удаляет объект, соответствующий параметру id
        /// </summary>
        /// <param name="id">Параметр, по которому ведется удаление</param>
        void Delete(IdType id);

        /// <summary>
        /// Проверяет существование записи в базе данных
        /// </summary>
        /// <param name="id">Параметр, по которому осуществляется поиск</param>
        /// <returns>Результат поиска</returns>
        bool Exists(IdType id);
    }
}
