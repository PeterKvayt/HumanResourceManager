using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    interface IConverter<DataTransferObject, PresentationLayerModel>
    {
        PresentationLayerModel Convert(DataTransferObject item);

        DataTransferObject Convert(PresentationLayerModel item);
    }
}
