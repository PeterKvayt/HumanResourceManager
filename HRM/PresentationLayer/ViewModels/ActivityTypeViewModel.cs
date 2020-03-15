using CommonClasses;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class ActivityTypeViewModel
    {
        public ActivityTypeModel ActivityTypeModel { get; set; }

        public IEnumerable<ActivityTypeModel> ActivityTypeCollection { get; set; }

    }
}
