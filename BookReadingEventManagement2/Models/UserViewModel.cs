using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace BookReadingEventManagement2.Models
{
    public class UserViewModel
    {
        
        public int? UserID { get; set; }

        [Required]
        public string Email { get; set; }
        
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool isAdmin { get; set; } = false;
    }
}