using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourceManager.DataAccessLayers
{
    public class StoredProcedure
    {
        /// <summary>
        /// Имя хранимой процедуры
        /// </summary>
        private string m_name { get; }

        /// <summary>
        /// Возвращает название хранимой процедуры
        /// </summary>
        public string Name
        {
            get
            {
                return m_name;
            }
        }

        /// <summary>
        /// Параметры хранимой процедуры
        /// </summary>
        private List<SqlParameter> m_sqlParameters;

        /// <summary>
        /// Возвращает список параметров хранимой процедуры
        /// </summary>
        public List<SqlParameter> SqlParameters
        {
            get
            {
                return m_sqlParameters;
            }
            //set
            //{
            //    if (value is List<SqlParameter> inputSqlParameters)
            //    {
            //        m_sqlParameters = inputSqlParameters;
            //    }
            //    else
            //    {
            //        // ToDo : сделать обработку неверного типа параметров хранимой процедуры
            //    }
            //}
        }

        /// <summary>
        /// Минимальное количество sql параметров для хранимой процедуры
        /// </summary>
        private const int m_sqlParametersCountMin = 1;

        /// <summary>
        /// Возвращает минимальное количество sql параметров для хранимой процедуры
        /// </summary>
        public static int SqlParametersCountMin
        {
            get
            {
                return m_sqlParametersCountMin;
            }
        }

        /// <summary>
        /// Создает экземпляр класса StoredProcedure
        /// </summary>
        /// <param name="storedProcedureName">Имя хранимой процедуры</param>
        /// <param name="sqlParameters">Параметры хранимой процедуры</param>
        public StoredProcedure(string storedProcedureName, List<SqlParameter> sqlParameters)
        {
            if (!string.IsNullOrEmpty(storedProcedureName) && !string.IsNullOrWhiteSpace(storedProcedureName))
            {
                if (sqlParameters.Count >= SqlParametersCountMin)
                {
                    m_name = storedProcedureName;
                    m_sqlParameters = sqlParameters;
                }
                else
                {
                    // ToDo: обработать неподходящее количество параметров хранимой процедуры
                }
            }
            else
            {
                // ToDo: обработать отсутствие названия процедуры
            }
        }

    }
}
