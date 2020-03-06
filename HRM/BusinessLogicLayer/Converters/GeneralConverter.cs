using BusinessLogicLayer.Mapper;
using DataAccessLayer.Interfaces;

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
            try
            {
                return AutoMapper<DataTransferObject>.Map(item);
            }
            catch (System.Exception)
            {
                // ToDo: exception
                throw;
            }
        }

        /// <summary>
        /// Создает объект, взаимодействующий с DataAccessLayer
        /// </summary>
        /// <param name="item">Объект, взаимодействующий с PresentationLayer</param>
        /// <returns>Объект, взаимодействующий с DataAccessLayer</returns>
        public virtual DataBaseEntity Convert(DataTransferObject item)
        {
            try
            {
                return AutoMapper<DataBaseEntity>.Map(item);
            }
            catch (System.Exception)
            {
                // ToDo: exception
                throw;
            }
        }

        /// <summary>
        /// Безопасно создает экземпляр типа TOut
        /// </summary>
        /// <typeparam name="TOut">Тип, экземпляр которого необходимо получить</typeparam>
        /// <typeparam name="Tin">Тип, из которого необходимо получить результат</typeparam>
        /// <param name="item">Экземпляр, преобразуемый в тип TOut</param>
        /// <returns>Результат преобразования</returns>
        protected virtual TOut TryMap<TOut, Tin>(Tin item) where TOut : new()
        {
            try
            {
                return AutoMapper<TOut>.Map(item);
            }
            catch (System.Exception)
            {
                // ToDo: exception
                throw;
            }
        }
    }
}
