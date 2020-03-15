using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class PositionViewModel
    {
        public PositionModel PositionModel { get; set; }

        public IEnumerable<PositionModel> PositionCollection { get; set; }
    }
}
