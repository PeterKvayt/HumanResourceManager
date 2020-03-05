using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Converters
{
    abstract class GeneralConverter<DataTransferObject, PresentationLayerModel>
    {
        public virtual PresentationLayerModel Convert(DataTransferObject item)
        {
            throw new NotImplementedException();
        }

        public virtual DataTransferObject Convert(PresentationLayerModel item)
        {
            throw new NotImplementedException();
        }
    }
}
