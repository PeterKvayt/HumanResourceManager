using CommonClasses;
using System;

namespace DataAccessLayer.Entities
{
    /// <summary>
    /// Класс отвечает за сущность базы данных "Сотрудник"
    /// </summary>
    public class Employee
    {
        public IdType Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Идентификатор места работы
        /// </summary>
        public IdType CompanyId { get; set; }

        /// <summary>
        /// Идентификатор должности
        /// </summary>
        public IdType PositionId { get; set; }

        /// <summary>
        /// Дата приема на работу
        /// </summary>
        public DateTime DateOfEmployment { get; set; }
    }
}
