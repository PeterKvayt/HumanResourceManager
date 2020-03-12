using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Loggers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer.DataContext
{
    class ActivityTypeDataAccessLayer : GeneralDataAccessLayer<ActivityType>, IDataAccessLayer<ActivityType>
    {
        public ActivityTypeDataAccessLayer(SqlConnection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Инициализирует параметры для создания записи в базе данных
        /// </summary>
        /// <param name="item">Экземпляр класса, который необходимо создать в базе данных</param>
        /// <returns>Список sql параметров для выполнения хранимой процедуры</returns>
        private List<SqlParameter> GetParametersForCreate(ActivityType item)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", item.Name)
            };

            return parameters;
        }

        public override void Create(ActivityType newActivity)
        {
            IEnumerable<SqlParameter> parameters = GetParametersForCreate(newActivity);

            const string CREATE_STORED_PROCEDURE_NAME = "spAddActivityType";

            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(CREATE_STORED_PROCEDURE_NAME, parameters, _connection);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception)
            {
                const string EXCEPTION_MESSAGE = "Ошибка создания ActivityType в классе ActivityTypeDataAccessLayer!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        /// <summary>
        /// Инициализирует параметры для обновления записи в базе данных
        /// </summary>
        /// <param name="item">Экземпляр класса, который необходимо обновить в базе данных</param>
        /// <returns>Список sql параметров для выполнения хранимой процедуры</returns>
        private List<SqlParameter> GetParametersForUpdate(ActivityType item)
        {
            SqlParameter idParameter = new SqlParameter("@Id", item.Id.Identificator);

            List<SqlParameter> parameters = GetParametersForCreate(item);
            parameters.Add(idParameter);

            return parameters;
        }

        public override void Update(ActivityType activityType)
        {
            IEnumerable<SqlParameter> parameters = GetParametersForUpdate(activityType);

            const string UPDATE_STORED_PROCEDURE_NAME = "spUpdateActivityType";

            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(UPDATE_STORED_PROCEDURE_NAME, parameters, _connection);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception)
            {
                const string EXCEPTION_MESSAGE = "Ошибка обновления экземпляра ActivityType в классе ActivityTypeDataAccessLayer!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public void Delete(IdType id)
        {
            const string DELETE_STORED_PROCEDURE_NAME = "spDeleteActivityType";
            Delete(id, DELETE_STORED_PROCEDURE_NAME);
        }

        public ActivityType Get(IdType id)
        {
            const string GET_STORED_PROCEDURE_NAME = "spGetActivityType";
            return Get(id, GET_STORED_PROCEDURE_NAME);
        }

        public IEnumerable<ActivityType> GetAll()
        {
            const string GET_ALL_STORED_PROCEDURE_NAME = "spGetAllActivityTypes";
            return GetAll(GET_ALL_STORED_PROCEDURE_NAME);
        }

        public bool Exists(IdType id)
        {
            const string EXISTS_STORED_PROCEDURE_NAME = "spExistsActivityType";
            return Exists(id, EXISTS_STORED_PROCEDURE_NAME);
        }
    }
}
