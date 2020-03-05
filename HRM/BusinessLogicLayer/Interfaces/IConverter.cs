using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    interface IConverter<DataTransferObject, BusinessModel>
    {
        BusinessModel Convert(DataTransferObject item);

        DataTransferObject Convert(BusinessModel item);
    }
}
