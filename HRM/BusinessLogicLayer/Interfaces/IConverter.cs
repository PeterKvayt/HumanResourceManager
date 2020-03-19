
namespace BusinessLogicLayer.Interfaces
{
    interface IConverter<EntityType, DataTransferObject>
    {
        /// <summary>
        /// Преобразует EntityType в DataTransferObject
        /// </summary>
        /// <param name="item">Объект для преобразования</param>
        /// <returns>Преобразованный</returns>
        DataTransferObject Convert(EntityType item);

        /// <summary>
        /// Преобразует DataTransferObject в  EntityType
        /// </summary>
        /// <param name="item">Объект для преобразования</param>
        /// <returns>Преобразованный</returns>
        EntityType Convert(DataTransferObject item);
    }
}
