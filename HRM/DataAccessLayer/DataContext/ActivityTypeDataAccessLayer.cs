using DataAccessLayer.Classes;
using DataAccessLayer.DataAccess;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.DataContext
{
    class ActivityTypeDataAccessLayer : IDataAccessLayer<ActivityType>
    {
        private const string CREATE_STORED_PROCEDURE_NAME = "spAddActivityType";
        public void Create(ActivityType newActivity)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", newActivity.Name)
            };

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

        private const string DELETE_STORED_PROCEDURE_NAME = "spDeleteActivityType";
        public void Delete(IdType id)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id.Identificator)
            };

            StoredProcedure storedProcedure = new StoredProcedure(DELETE_STORED_PROCEDURE_NAME, storedProcedureParameters);

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

        private const string GET_STORED_PROCEDURE_NAME = "spGetActivityType";
        public ActivityType Get(IdType id)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id.Identificator)
            };

            StoredProcedure storedProcedure = new StoredProcedure(GET_STORED_PROCEDURE_NAME, storedProcedureParameters);

            DataSet resultDataSet = storedProcedure.Execute();

            if (resultDataSet != null)
            {
                ActivityType resultActivityType = DataTableMapper.CreateObjectFromTable<ActivityType>(resultDataSet.Tables[0]);

                return resultActivityType;
            }
            else
            {
                // ToDo: exception
                throw new ArgumentNullException();
            }
        }

        private const string GET_ALL_STORED_PROCEDURE_NAME = "spGetAllActivityTypes";
        public IEnumerable<ActivityType> GetAll()
        {
            StoredProcedure storedProcedure = new StoredProcedure(GET_ALL_STORED_PROCEDURE_NAME, new List<SqlParameter> { });

            DataSet resultDataSet = storedProcedure.Execute();

            if (resultDataSet != null)
            {
                List<ActivityType> companyCollection = DataTableMapper.CreateListFromTable<ActivityType>(resultDataSet.Tables[0]);

                return companyCollection;
            }
            else
            {
                // ToDo: exception
                throw new ArgumentNullException();
            }
        }

        private const string UPDATE_STORED_PROCEDURE_NAME = "spUpdateActivityType";
        public void Update(ActivityType activityType)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", activityType.Id),
                new SqlParameter("@Name", activityType.Name)
            };

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

        public IEnumerable<ActivityType> Find(Func<ActivityType, bool> predicate)
        {
            // ToDo: find
            throw new NotImplementedException();
        }
    }
}
