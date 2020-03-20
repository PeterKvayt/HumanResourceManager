using ExceptionClasses.Loggers;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CommonClasses
{
    /// <summary>
    /// Класс, автоматизирующий создание объектов типа TOut 
    /// </summary>
    /// <typeparam name="TOut">Тип, в который необходимо преобразовать объект</typeparam>
    public static class AutoMapper<TOut> where TOut: new()
    {
        private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> _propertiesDictionaries
            = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

        /// <summary>
        /// Преобразует передаваемый объект в объект типа TOut
        /// </summary>
        /// <param name="obj">Преобразуемый тип</param>
        /// <returns>Тип, который необходимо получить</returns>
        public static TOut Map(object obj)
        {
            var objProperties = GetProperties(obj.GetType());

            var resultProperties = GetProperties(typeof(TOut));

            var result = new TOut();

            foreach (var resultProperty in resultProperties)
            {
                if (objProperties.TryGetValue(resultProperty.Key, out var objProperty))
                {
                    resultProperty.Value.SetValue(result, objProperty.GetValue(obj));
                }
                else
                {
                    string EXCEPTION_MESSAGE = $"Ошибка извлечения значения при сопоставлении свойств классов {obj.GetType().ToString()} и {typeof(TOut).ToString()}, " +
                        $"связанная со свойством {resultProperty.Value.Name}";

                    ExceptionLogger.Log(EXCEPTION_MESSAGE, typeof(AutoMapper<TOut>).Name, "Map");

                    throw new Exception();
                }
            }

            return result;
        }

        /// <summary>
        /// Возвращает свойства передаваемого объекта
        /// </summary>
        /// <param name="objType">Тип, свойства которого необходимо получить</param>
        /// <returns>Возвращаемые свойства</returns>
        private static Dictionary<string, PropertyInfo> GetProperties(Type objType)
        {
            if (!_propertiesDictionaries.TryGetValue(objType, out var propertiesInfoDictionary))
            {
                var infos = objType.GetProperties();

                propertiesInfoDictionary = new Dictionary<string, PropertyInfo>();

                foreach (var propertyInfo in infos)
                {
                    propertiesInfoDictionary.Add(propertyInfo.Name, propertyInfo);
                }

                _propertiesDictionaries.Add(objType, propertiesInfoDictionary);
            }
            
            return propertiesInfoDictionary;
        }
    }
}
