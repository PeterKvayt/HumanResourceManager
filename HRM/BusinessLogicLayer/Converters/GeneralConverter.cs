using CommonClasses;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Logers;
using System;

namespace BusinessLogicLayer.Converters
{
    /// <summary>
    /// Класс отвечает за общую реализацию классов, реализующих интерфейс IConverter
    /// </summary>
    /// <typeparam name="DataTransferObject">Буферный тип, с которым взаимодействует WebAPI</typeparam>
    /// <typeparam name="EntityType">Сущность базы данных</typeparam>
    abstract class GeneralConverter<EntityType, DataTransferObject> 
        where EntityType: new()
        where DataTransferObject: new()
    {
        /// <summary>
        /// Предоставляет доступ к данным для конвертеров
        /// </summary>
        protected IUnitOfWork _dataBase;

        /// <summary>
        /// Создает объект, взаимодействующий с PresentationLayer
        /// </summary>
        /// <param name="item">Объект, взаимодействующий с DataAccessLayer</param>
        /// <returns>Объект, взаимодействующий с PresentationLayer</returns>
        public virtual DataTransferObject Convert(EntityType item)
        {
            return TryMap<DataTransferObject, EntityType> (item);
        }

        /// <summary>
        /// Создает объект, взаимодействующий с DataAccessLayer
        /// </summary>
        /// <param name="item">Объект, взаимодействующий с PresentationLayer</param>
        /// <returns>Объект, взаимодействующий с DataAccessLayer</returns>
        public virtual EntityType Convert(DataTransferObject item)
        {
            return TryMap<EntityType, DataTransferObject>(item);
        }

        /// <summary>
        /// Безопасно преобразует экземпляр в тип TOut
        /// </summary>
        /// <typeparam name="TOut">Тип, экземпляр которого необходимо получить</typeparam>
        /// <typeparam name="TIn">Тип, из которого необходимо получить результат</typeparam>
        /// <param name="item">Экземпляр, преобразуемый в тип TOut</param>
        /// <returns>Результат преобразования</returns>
        protected virtual TOut TryMap<TOut, TIn>(TIn item) where TOut : new()
        {
            try
            {
                return AutoMapper<TOut>.Map(item);
            }
            catch (Exception exception)
            {
                ExceptionLoger.Log(exception);

                throw;
            }
        }
    }
}
