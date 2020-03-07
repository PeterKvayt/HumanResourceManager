using BusinessLogicLayer.Mapper;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Loggers;

namespace BusinessLogicLayer.Converters
{
    abstract class GeneralConverter<DataBaseEntity, DataTransferObject> 
        where DataBaseEntity: new()
        where DataTransferObject: new()
    {
        protected IUnitOfWork _dataBase;

        /// <summary>
        /// Создает объект, взаимодействующий с PresentationLayer
        /// </summary>
        /// <param name="item">Объект, взаимодействующий с DataAccessLayer</param>
        /// <returns>Объект, взаимодействующий с PresentationLayer</returns>
        public virtual DataTransferObject Convert(DataBaseEntity item)
        {
            return TryMap<DataTransferObject, DataBaseEntity> (item);
        }

        /// <summary>
        /// Создает объект, взаимодействующий с DataAccessLayer
        /// </summary>
        /// <param name="item">Объект, взаимодействующий с PresentationLayer</param>
        /// <returns>Объект, взаимодействующий с DataAccessLayer</returns>
        public virtual DataBaseEntity Convert(DataTransferObject item)
        {
            return TryMap<DataBaseEntity, DataTransferObject>(item);
        }

        /// <summary>
        /// Безопасно создает экземпляр типа TOut
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
            catch (System.Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка преобразования класса {typeof(TIn).ToString()} в {typeof(TOut).ToString()} в классе GeneralConverter";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }
    }
}
