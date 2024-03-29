﻿using BusinessLogicLayer.Interfaces;
using CommonClasses;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class LegalFormDTO : IDataTransferObject
    {
        public IdType Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
