using PresentationLayer.Models;
using System.Collections.Generic;

namespace PresentationLayer.ViewModels
{
    public class PositionViewModel
    {
        public PositionModel PositionModel { get; set; }

        public IEnumerable<PositionModel> PositionCollection { get; set; }
    }
}
