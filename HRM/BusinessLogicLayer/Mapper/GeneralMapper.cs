using System;
using System.Collections.Generic;
using System.Reflection;

namespace BusinessLogicLayer.Mapper
{
    class GeneralMapper<T>
    {
        private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> _propertiesDictionaries
            = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

        public virtual T Map<T>(object obj) where T : new()
        {
            var objProperties = GetProperties(obj.GetType());
            var resultProperties = GetProperties(typeof(T));
            var result = new T();
            foreach (var resultProperty in resultProperties)
            {
                if (objProperties.TryGetValue(resultProperty.Key, out var objProperty))
                {
                    resultProperty.Value.SetValue(result, objProperty.GetValue(obj));
                }
            }
            return result;
        }

        private Dictionary<string, PropertyInfo> GetProperties(Type objType)
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
