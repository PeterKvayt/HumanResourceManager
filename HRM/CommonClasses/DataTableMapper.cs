using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using ExceptionClasses.Loggers;

namespace CommonClasses
{
    /// <summary>
    /// Класс, автоматизирующий создание объектов из контекста данных 
    /// </summary>
    public class DataTableMapper
    {
        /// <summary>
        /// Контекст данных, из которого создаются объекты
        /// </summary>
        private readonly DataTable _dataContext;

        private const string ID_TYPE_CLASS = "CommonClasses.IdType";

        public DataTableMapper(DataTable dataTable)
        {
            if (dataTable != null)
            {
                _dataContext = dataTable;
            }
            else
            {
                const string EXCEPTION_MESSAGE = "Отсутствует контекст данных DataTable (dataTable = null)!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw new Exception();
            }
        }

        /// <summary>
        /// Создает из DataTable один объект
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого объекта</typeparam>
        /// <param name="dataTable">Контекст данных, из которого будет создаваться объект</param>
        /// <returns>Возвращает созданный объект передаваемого типа T</returns>
        public T CreateObjectFromTable<T>() where T : class, new()
        {
            T resultObject = new T();

            DataRow  row = _dataContext.Rows[0];

            SetItemFromRow(resultObject, row);

            return resultObject;
        }

        /// <summary>
        /// Создает из DataTable список объектов
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого списка объектов</typeparam>
        /// <param name="dataTable">Контекст данных, из которого будет создаваться список объектов</param>
        /// <returns>Возвращает список созданных объектов передаваемого типа T</returns>
        public IEnumerable<T> CreateListFromTable<T>() where T : new()
        {
            List<T> resultListWithObjects = new List<T>();

            foreach (DataRow row in _dataContext.Rows)
            {
                resultListWithObjects.Add(GetItemFromRow<T>(row));
            }
            return resultListWithObjects;
        }

        /// <summary>
        /// Возвращает объект из строки DataRow
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="row">Строка DataRow</param>
        /// <returns>Объект передаваемого типа</returns>
        private T GetItemFromRow<T>(DataRow row) where T : new()
        {
            T item = new T();

            SetItemFromRow(item, row);

            return item;
        }

        /// <summary>
        /// Создает объект из строки DataRow
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="inputItem">Экземпляр объекта</param>
        /// <param name="row">Строка DataRow</param>
        private void SetItemFromRow<T>(T inputItem, DataRow row) where T : new()
        {
            foreach (DataColumn column in row.Table.Columns)
            {
                Type type = inputItem.GetType();

                PropertyInfo property = type.GetProperty(column.ColumnName);

                if (property != null )
                {
                    if (row[column] != DBNull.Value)
                    {
                        if (property.PropertyType.ToString() == ID_TYPE_CLASS)
                        {
                            IdType id = new IdType
                            {
                                Identificator = Convert.ToUInt32(row[column])
                            };
                            property.SetValue(inputItem, id);
                        }
                        else
                        {
                            property.SetValue(inputItem, row[column]);
                        }
                        //property.SetValue(inputItem, row[column], null);
                    }
                    else
                    {
                        const string EXCEPTION_MESSAGE = "Значение ячейки в строке DataTable = DBNull.Value!";

                        ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                        throw new Exception();
                    }
                }
                else
                {
                    const string EXCEPTION_MESSAGE = "Отсутствует свойство (property = null)!";

                    ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                    throw new Exception();
                }
            }
        }
    }
}
