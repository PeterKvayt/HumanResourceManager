using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Classes
{
    public class IdType
    {
        public uint Identificator { get; set; }

        internal Repositories.ActivityTypeRepository ActivityTypeRepository
        {
            get => default(Repositories.ActivityTypeRepository);
            set
            {
            }
        }
    }
}
