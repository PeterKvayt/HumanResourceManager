using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BusinessLogicLayer.Mapper
{
    static class AutoMapper<TOut> where TOut: new()
    {
        private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> _propertiesDictionaries
            = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

        /// <summary>
        /// Преобразует один тип в другой, при условии соответствия свойств
        /// </summary>
        /// <param name="obj">Преобразуемый тип</param>
        /// <returns>Тип, который необходимо получить</returns>
        public static TOut Map(object obj)
        {
            var objProperties = TryGetProperties(obj.GetType());

            var resultProperties = TryGetProperties(typeof(TOut));

            var result = new TOut();

            foreach (var resultProperty in resultProperties)
            {
                if (objProperties.TryGetValue(resultProperty.Key, out var objProperty))
                {
                    resultProperty.Value.SetValue(result, objProperty.GetValue(obj));
                }
                else
                {
                    // ToDo: exception
                    throw new Exception();
                }
            }

            return result;
        }

        /// <summary>
        /// Создает свойства передаваемого объекта
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
            else
            {
                // ToDo: exception
                throw new Exception();
            }
            return propertiesInfoDictionary;
        }

        /// <summary>
        /// Безопасно создает свойства передаваемого объекта
        /// </summary>
        /// <param name="objType">Тип, свойства которого необходимо получить</param>
        /// <returns>Возвращаемые свойства</returns>
        private static Dictionary<string, PropertyInfo> TryGetProperties(Type objType)
        {
            try
            {
                return GetProperties(objType);
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
        }
    }
}
