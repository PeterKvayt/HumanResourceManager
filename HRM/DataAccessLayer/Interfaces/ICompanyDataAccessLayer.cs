
namespace DataAccessLayer.Interfaces
{
    interface ICompanyDataAccessLayer<EntityType> : IDataAccessLayer<EntityType> where EntityType : class
    {
        /// <summary>
        /// Возвращает размер компании
        /// </summary>
        /// <param name="item">Компания</param>
        /// <returns>Размер компании</returns>
        int GetSize(EntityType item);
    }
}
