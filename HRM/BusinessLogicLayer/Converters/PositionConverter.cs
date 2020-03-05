using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.PresentationLayerModels;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Converters
{
    class PositionConverter : GeneralConverter<PositionDTO, PositionPLM>, IConverter<PositionDTO, PositionPLM>
    {
        public PositionConverter(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
        }
    }
}
