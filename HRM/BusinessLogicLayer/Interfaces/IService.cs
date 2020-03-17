using CommonClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    public interface IService<DataTransferObject>
    {
        /// <summary>
        /// Возвращает все объекты 
        /// </summary>
        /// <returns></returns>
        IEnumerable<DataTransferObject> GetAll();

        /// <summary>
        /// Возвращает объект, соответствующий параметру id 
        /// </summary>
        /// <param name="id">Параметр, по которому ведется поиск</param>
        /// <returns></returns>
        DataTransferObject Get(uint? id);

        /// <summary>
        /// Создает объект в базе данных
        /// </summary>
        /// <param name="item"></param>
        void Create(DataTransferObject item);

        /// <summary>
        /// Обновляет объект в базе данных 
        /// </summary>
        /// <param name="item">Обновляемый объект</param>
        void Update(DataTransferObject item);

        /// <summary>
        /// Удаляет объект, соответствующий параметру id
        /// </summary>
        /// <param name="id">Параметр, по которому ведется удаление</param>
        void Delete(uint? id);
    }
}
