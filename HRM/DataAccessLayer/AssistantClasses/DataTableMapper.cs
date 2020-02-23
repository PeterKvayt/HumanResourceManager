using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace DataAccessLayer.AssistantClasses
{
    internal static class DataTableMapper
    {
        public static T CreateObjectFromTable<T>(DataTable inputDataTable) where T : class, new()
        {
            T resultObject = new T();

            foreach (DataRow row in inputDataTable.Rows)
            {
                resultObject = CreateItemFromRow<T>(row);
            }
            return resultObject;
        }

        /// <summary>
        /// Создает из DataTable список объектов
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого списка объектов</typeparam>
        /// <param name="inputDataTable"></param>
        /// <returns></returns>
        public static List<T> CreateListFromTable<T>(DataTable inputDataTable) where T : new()
        {
            List<T> resultListWithObjects = new List<T>();

            foreach (DataRow row in inputDataTable.Rows)
            {
                resultListWithObjects.Add(CreateItemFromRow<T>(row));
            }
            return resultListWithObjects;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <returns></returns>
        private static T CreateItemFromRow<T>(DataRow row) where T : new()
        {
            T item = new T();

            SetItemFromRow(item, row);

            return item;
        }

        /// <summary>
        /// Задает значения свойствам объекта
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="inputItem">Экземпляр объекта</param>
        /// <param name="inputRow">Строка DataRow</param>
        private static void SetItemFromRow<T>(T inputItem, DataRow inputRow) where T : new()
        {
            foreach (DataColumn column in inputRow.Table.Columns)
            {
                Type type = inputItem.GetType();

                PropertyInfo property = type.GetProperty(column.ColumnName);

                if (property != null && inputRow[column] != DBNull.Value)
                {
                    //property.SetValue(inputItem, inputRow[column], null);
                    property.SetValue(inputItem, inputRow[column]);
                }
            }
        }
    }
}
