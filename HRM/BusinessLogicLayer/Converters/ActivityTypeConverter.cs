﻿using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.PresentationLayerModels;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Converters
{
    class ActivityTypeConverter : GeneralConverter<ActivityTypeDTO, ActivityTypePLM>, IConverter<ActivityTypeDTO, ActivityTypePLM>
    {
        public ActivityTypeConverter(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
        }
    }
}
