using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Thomas_Gaming_Club.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Please choose a preferred contact")]
        public string PreferredContact { get; set; }

        [Required(ErrorMessage = "Please choose an identifier")]
        public string PreferredTitle { get; set; }

        [Required(ErrorMessage = "Please enter a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "The email address entered is not valid")]
        [Key]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required(ErrorMessage = "Please describe your reason for contacting us")]
        public string Message { get; set; }

    }
}