using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookReadingEventManagement2.Models
{
    public class EventDetailViewModel
    {
        public int? EventID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        public string Location { get; set; }

        [Range(0, 4, ErrorMessage = "Duration should be between 0 and 4 only")]
        public int? Duration { get; set; } = 4;

        [MaxLength(50, ErrorMessage = "Maximum Length is 50 characters")]
        public string Description { get; set; }

        [MaxLength(500, ErrorMessage = "Maximum Length is 500 Characters")]
        public string OtherDetails { get; set; }
        public int InviteCount { get; set; }
        public string InviteString { get; set; }
        public string[] Invites { get; set; }
        public string UserFullName { get; set; }
        public int UserID { get; set; }
        public string Type { get; set; } = "Public";
        public string CurrentUser { get; set; }
        public List<CommentViewModel> CommentList { get; set; }
        public CommentViewModel Comment { get; set; }
    }
}