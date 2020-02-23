using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; } //Set Default to false
    }
}
