using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class PositionViewModel
    {
        public PositionModel Position { get; set; }

        public IEnumerable<PositionModel> PositionCollection { get; set; }
    }
}
