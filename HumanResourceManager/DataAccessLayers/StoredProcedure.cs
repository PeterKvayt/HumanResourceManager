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
        public string Name { get; }

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
        /// Создает экземпляр класса StoredProcedure
        /// </summary>
        /// <param name="storedProcedureName">Имя хранимой процедуры</param>
        /// <param name="sqlParameters">Параметры хранимой процедуры</param>
        public StoredProcedure(string storedProcedureName, List<SqlParameter> sqlParameters)
        {
            if (!string.IsNullOrEmpty(storedProcedureName) && !string.IsNullOrWhiteSpace(storedProcedureName))
            {
                Name = storedProcedureName;
            }
            else
            {
                // ToDo: обработать отсутствие названия процедуры
            }

            if (sqlParameters.Count >= 1)
            {
                m_sqlParameters = sqlParameters;
            }
            else
            {
                // ToDo: обработать отсутствие параметров хранимой процедуры
            }
        }

    }
}
