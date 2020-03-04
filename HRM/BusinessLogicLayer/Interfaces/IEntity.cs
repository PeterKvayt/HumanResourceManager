using CommonClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    interface IEntity
    {
        IdType Id { get; set; }
    }
}
