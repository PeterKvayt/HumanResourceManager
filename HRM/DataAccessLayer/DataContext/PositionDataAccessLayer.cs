﻿using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer.DataContext
{
    class PositionDataAccessLayer : GeneralDataAccessLayer<Position>, IDataAccessLayer<Position>
    {
        /// <summary>
        /// Инициализирует параметры для создания записи в базе данных
        /// </summary>
        /// <param name="item">Экземпляр класса, который необходимо создать в базе данных</param>
        /// <returns>Список sql параметров для выполнения хранимой процедуры</returns>
        private List<SqlParameter> GetParametersForCreate(Position item)
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
        public void Create(Position newPosition)
        {
            IEnumerable<SqlParameter> parameters = GetParametersForCreate(newPosition);

            const string CREATE_STORED_PROCEDURE_NAME = "spAddPosition";

            Create(parameters, CREATE_STORED_PROCEDURE_NAME);
        }

        /// <summary>
        /// Инициализирует параметры для обновления записи в базе данных
        /// </summary>
        /// <param name="item">Экземпляр класса, который необходимо обновить в базе данных</param>
        /// <returns>Список sql параметров для выполнения хранимой процедуры</returns>
        private List<SqlParameter> GetParametersForUpdate(Position item)
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
        public void Update(Position position)
        {
            IEnumerable<SqlParameter> parameters = GetParametersForUpdate(position);

            const string UPDATE_STORED_PROCEDURE_NAME = "spUpdatePosition";

            Update(parameters, UPDATE_STORED_PROCEDURE_NAME);
        }

        public void Delete(IdType id)
        {
            const string DELETE_STORED_PROCEDURE_NAME = "spDeletePosition";
            Delete(id, DELETE_STORED_PROCEDURE_NAME);
        }

        public Position Get(IdType id)
        {
            const string GET_STORED_PROCEDURE_NAME = "spGetPosition";

            IEnumerable<SqlParameter> parameters = GetIdParameters(id);

            return GetResultCollection(GET_STORED_PROCEDURE_NAME, parameters, MapCollection)[0];
        }

        public IEnumerable<Position> GetAll()
        {
            const string GET_ALL_STORED_PROCEDURE_NAME = "spGetAllPositions";

            return GetResultCollection(GET_ALL_STORED_PROCEDURE_NAME, new List<SqlParameter> { }, MapCollection);
        }

        private List<Position> MapCollection(SqlDataReader reader)
        {
            var resultCollection = new List<Position> { };

            while (reader.Read())
            {
                var position = new Position
                {
                    Id = MapIdType(reader["Id"]),
                    Name = reader["Name"].ToString()
                };

                resultCollection.Add(position);
            }

            return resultCollection;
        }

        public bool Exists(IdType id)
        {
            const string EXISTS_STORED_PROCEDURE_NAME = "spExistsPosition";
            return Exists(id, EXISTS_STORED_PROCEDURE_NAME);
        }
    }
}
