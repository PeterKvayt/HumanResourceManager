using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.PresentationLayerModels;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Converters
{
    class LegalFormConverter : GeneralConverter<LegalFormDTO, LegalFormPLM>, IConverter<LegalFormDTO, LegalFormPLM>
    {
        public LegalFormConverter(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
        }
    }
}
