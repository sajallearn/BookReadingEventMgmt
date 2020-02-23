using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace BookReadingEventManagement2.Models
{
    public class RegisterViewModel
    {
        
        public int? UserID { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.{5,})(?=.*[@#$%^&+=]).*$", ErrorMessage = "Password must be more than 5 characters and must contain atleast 1 special character")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare("Password")]
        [IgnoreMap]
        public string ConfirmPassword { get; set; } 
        public bool isAdmin { get; set; } = false;
    }
}