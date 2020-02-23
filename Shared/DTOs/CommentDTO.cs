using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class CommentDTO
    {
        public int CommentID { get; set; }
        public int EventID { get; set; }
        public string UserFullName { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public string Data { get; set; }
    }
}
