using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookReadingEventManagement2.Models
{
    public class PartialEventViewModel
    {
        public int? EventID { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }
        public string UserFullName { get; set; }
    }
}