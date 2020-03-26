
using System;

namespace CommonClasses
{
    /// <summary>
    /// Класс отвечает за идентификатор
    /// </summary>
    public class IdType
    {
        public uint Identifier { get; set; }

        /// <summary>
        /// Преобразует идентификатор в тип, поддерживаемый базой данных
        /// </summary>
        /// <returns>Экземпляр типа, известного базе данных</returns>
        public int ConvertToDBTypeId()
        {
            return Convert.ToInt32(Identifier);
        }
    }
}
