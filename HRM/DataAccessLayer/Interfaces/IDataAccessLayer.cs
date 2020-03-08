using CommonClasses;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    interface IDataAccessLayer<EntityType> where EntityType : class
    {
        /// <summary>
        /// Возвращает все объекты 
        /// </summary>
        /// <returns></returns>
        IEnumerable<EntityType> GetAll();

        /// <summary>
        /// Возвращает объект, соответствующий параметру id 
        /// </summary>
        /// <param name="id">Параметр, по которому ведется поиск</param>
        /// <returns></returns>
        EntityType Get(IdType id);

        /// <summary>
        /// Создает объект в базе данных
        /// </summary>
        /// <param name="item"></param>
        void Create(EntityType item);

        /// <summary>
        /// Обновляет объект в базе данных 
        /// </summary>
        /// <param name="item">Обновляемый объект</param>
        void Update(EntityType item);

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

