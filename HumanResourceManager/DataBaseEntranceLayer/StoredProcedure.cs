using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HumanResourceManager.DataBaseEntranceLayer
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
        /// Создает экземпляр класса StoredProcedure
        /// </summary>
        /// <param name="storedProcedureName">Имя хранимой процедуры</param>
        /// <param name="sqlParameters">Параметры хранимой процедуры</param>
        public StoredProcedure(string storedProcedureName, List<SqlParameter> sqlParameters)
        {
            if ( !(string.IsNullOrEmpty(storedProcedureName) && string.IsNullOrWhiteSpace(storedProcedureName)) )
            {
                if (sqlParameters.Count >= GetSqlParametersCountMin())
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

        /// <summary>
        /// Минимальное количество sql параметров для хранимой процедуры
        /// </summary>
        private const int m_SQL_PARAMETERS_COUNT_MIN = 1;

        /// <summary>
        /// Возвращает минимальное количество sql параметров для хранимой процедуры
        /// </summary>
        public static int GetSqlParametersCountMin()
        {
            return m_SQL_PARAMETERS_COUNT_MIN;
        }

        /// <summary>
        /// Константа тип команды для создания sql-команд
        /// </summary>
        private const CommandType m_COMMAND_TYPE = CommandType.StoredProcedure;

        /// <summary>
        /// Возвращает константу тип команды для создания sql-команд
        /// </summary>
        public static CommandType GetCommandType()
        {
            return m_COMMAND_TYPE;
        }

    }
}
