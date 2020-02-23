using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Event
    {
        public int EventID { get; set; }
        public string Title { get; set; }
        public DateTime StartDateAndTime { get; set; }
        public string Location { get; set; }
        public int? Duration { get; set; }
        public string Description { get; set; }
        public string OtherDetails { get; set; }
        public int InviteCount { get; set; }
        public int UserID { get; set; }
        public bool isPublic { get; set; }
        public string UserFullName { get; set; }
    }
}
