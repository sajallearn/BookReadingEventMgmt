using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookReadingEventManagement2.Models
{
    public class EventListViewModel
    {
        public List<PartialEventViewModel> UpcomingEvents { get; set; }
        public List<PartialEventViewModel> PastEvents { get; set; }
    }
}