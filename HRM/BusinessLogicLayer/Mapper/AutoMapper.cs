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
            }
            return result;
        }

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
