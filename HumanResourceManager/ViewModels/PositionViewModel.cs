using HumanResourceManager.Models;
using System.Collections.Generic;

namespace HumanResourceManager.ViewModels
{
    public class PositionViewModel
    {
        public List<Position> Positions { get; set; }

        public string SotrType { get; set; }

        public PositionViewModel(List<Position> positions, string sotrType)
        {
            Positions = positions;
            SotrType = sotrType;
        }

        public PositionViewModel()
        {
        }
    }
}
