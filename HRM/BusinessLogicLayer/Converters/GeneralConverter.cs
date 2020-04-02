using DataAccessLayer.Interfaces;

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
    }
}
