using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    interface IConverter<EntityType, DataTransferObject>
    {
        DataTransferObject Convert(EntityType item);

        EntityType Convert(DataTransferObject item);
    }
}
