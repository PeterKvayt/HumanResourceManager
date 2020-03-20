using PresentationLayer.Models;
using System.Collections.Generic;

namespace PresentationLayer.ViewModels
{
    public class ActivityTypeViewModel
    {
        public ActivityTypeModel ActivityTypeModel { get; set; }

        public IEnumerable<ActivityTypeModel> ActivityTypeCollection { get; set; }

    }
}
