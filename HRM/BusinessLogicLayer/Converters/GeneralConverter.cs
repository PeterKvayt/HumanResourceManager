using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Converters
{
    abstract class GeneralConverter<DataTransferObject, BusinessModel>
    {
        public virtual BusinessModel Convert(DataTransferObject item)
        {
            throw new NotImplementedException();
        }

        public virtual DataTransferObject Convert(BusinessModel item)
        {
            throw new NotImplementedException();
        }
    }
}
