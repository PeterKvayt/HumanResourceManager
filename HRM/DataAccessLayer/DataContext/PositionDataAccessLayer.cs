using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Loggers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer.DataContext
{
    class PositionDataAccessLayer : GeneralDataAccessLayer<Position>, IDataAccessLayer<Position>
    {
        public override void Create(Position newPosition)
        {
            IEnumerable<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", newPosition.Name)
            };

            const string CREATE_STORED_PROCEDURE_NAME = "spAddPosition";
            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(CREATE_STORED_PROCEDURE_NAME, storedProcedureParameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception)
            {
                const string EXCEPTION_MESSAGE = "Ошибка создания экземпляра класса Position в классе PositionDataAccessLayer!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public override void Update(Position position)
        {
            IEnumerable<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", position.Id.Identificator),
                new SqlParameter("@Name", position.Name)
            };

            const string UPDATE_STORED_PROCEDURE_NAME = "spUpdatePosition";
            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(UPDATE_STORED_PROCEDURE_NAME, storedProcedureParameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception)
            {
                const string EXCEPTION_MESSAGE = "Ошибка обновления экземпляра класса Position в классе PositionDataAccessLayer!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public void Delete(IdType id)
        {
            const string DELETE_STORED_PROCEDURE_NAME = "spDeletePosition";
            Delete(id, DELETE_STORED_PROCEDURE_NAME);
        }

        public Position Get(IdType id)
        {
            const string GET_STORED_PROCEDURE_NAME = "spGetPosition";
            return Get(id, GET_STORED_PROCEDURE_NAME);
        }

        public IEnumerable<Position> GetAll()
        {
            const string GET_ALL_STORED_PROCEDURE_NAME = "spGetAllPositions";
            return GetAll(GET_ALL_STORED_PROCEDURE_NAME);
        }
    }
}
