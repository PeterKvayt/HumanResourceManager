using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer.DataContext
{
    class ActivityTypeDataAccessLayer : GeneralDataAccessLayer<ActivityType>, IDataAccessLayer<ActivityType>
    {
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

        /// <summary>
        /// Создает новую запись в базе данных
        /// </summary>
        /// <param name="item">Новый экземпляр класса</param>
        public void Create(ActivityType newActivity)
        {
            IEnumerable<SqlParameter> parameters = GetParametersForCreate(newActivity);

            const string CREATE_STORED_PROCEDURE_NAME = "spAddActivityType";

            Create(parameters, CREATE_STORED_PROCEDURE_NAME);
        }

        /// <summary>
        /// Инициализирует параметры для обновления записи в базе данных
        /// </summary>
        /// <param name="item">Экземпляр класса, который необходимо обновить в базе данных</param>
        /// <returns>Список sql параметров для выполнения хранимой процедуры</returns>
        private List<SqlParameter> GetParametersForUpdate(ActivityType item)
        {
            List<SqlParameter> idParameter = GetIdParameters(item.Id);

            List<SqlParameter> parameters = GetParametersForCreate(item);
            foreach (var idParam in idParameter)
            {
                parameters.Add(idParam);
            }

            return parameters;
        }

        /// <summary>
        /// Обновляет запись в базе данных
        /// </summary>
        /// <param name="item">Экземпляр класса, который необходимо обновить</param>
        public void Update(ActivityType activityType)
        {
            IEnumerable<SqlParameter> parameters = GetParametersForUpdate(activityType);

            const string UPDATE_STORED_PROCEDURE_NAME = "spUpdateActivityType";

            Update(parameters, UPDATE_STORED_PROCEDURE_NAME);
        }

        public void Delete(IdType id)
        {
            const string DELETE_STORED_PROCEDURE_NAME = "spDeleteActivityType";
            Delete(id, DELETE_STORED_PROCEDURE_NAME);
        }

        public ActivityType Get(IdType id)
        {
            const string GET_STORED_PROCEDURE_NAME = "spGetActivityType";

            IEnumerable<SqlParameter> parameters = GetIdParameters(id);

            return GetResultCollection(GET_STORED_PROCEDURE_NAME, parameters, MapCollection)[0];
        }

        public IEnumerable<ActivityType> GetAll()
        {
            const string GET_ALL_STORED_PROCEDURE_NAME = "spGetAllActivityTypes";

            return GetResultCollection(GET_ALL_STORED_PROCEDURE_NAME, new List<SqlParameter> { }, MapCollection);
        }

        /// <summary>
        /// Создает все сущности из базы данных
        /// </summary>
        /// <param name="reader">Ридер, содержащий все записи из базы данных</param>
        /// <returns>Все сущности из базы данных</returns>
        private List<ActivityType> MapCollection(SqlDataReader reader)
        {
            var resultCollection = new List<ActivityType> { };

            while (reader.Read())
            {
                var activityType = new ActivityType
                {
                    Id = MapIdType(reader["Id"]),
                    Name = reader["Name"].ToString()
                };

                resultCollection.Add(activityType);
            }

            return resultCollection;
        }

        public bool Exists(IdType id)
        {
            const string EXISTS_STORED_PROCEDURE_NAME = "spExistsActivityType";
            return Exists(id, EXISTS_STORED_PROCEDURE_NAME);
        }
    }
}
