using DataAccessLayer.AssistantClasses;
using DataAccessLayer.DataAccess;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.DataContext
{
    class ActivityTypeDataAccessLayer : GeneralDataAccessLayer<ActivityType>, IDataAccessLayer<ActivityType>
    {
        public override void Create(ActivityType newActivity)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", newActivity.Name)
            };

            const string CREATE_STORED_PROCEDURE_NAME = "spAddActivityType";
            StoredProcedure storedProcedure = new StoredProcedure(CREATE_STORED_PROCEDURE_NAME, storedProcedureParameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
        }

        public override void Update(ActivityType activityType)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", activityType.Id.Identificator),
                new SqlParameter("@Name", activityType.Name)
            };

            const string UPDATE_STORED_PROCEDURE_NAME = "spUpdateActivityType";
            StoredProcedure storedProcedure = new StoredProcedure(UPDATE_STORED_PROCEDURE_NAME, storedProcedureParameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // ToDo: exception
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

        public override IEnumerable<ActivityType> Find(Func<ActivityType, bool> predicate)
        {
            // ToDo: find
            throw new NotImplementedException();
        }
    }
}
