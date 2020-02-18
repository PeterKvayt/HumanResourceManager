using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    interface IDataAccess
    {
        DataSet Execute();

        void ExecuteNonQuery();
    }
}
