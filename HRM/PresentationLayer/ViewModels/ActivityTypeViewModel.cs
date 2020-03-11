using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class ActivityTypeViewModel
    {
        public IEnumerable<ActivityTypeModel> ActivityTypeCollection { get; }

        public ActivityTypeViewModel(IEnumerable<ActivityTypeModel> activityTypeCollection)
        {
            ActivityTypeCollection = activityTypeCollection;
        }
    }
}
