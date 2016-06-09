using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Email.Models
{
    public class EmailForm
    {
        [Required, Display(Name="Your Name")]
        public string FromName { get; set; }
        [Required, Display(Name ="Your Email")]
        public string FromEmail { get; set; }
        [Required]
        public string Message { get; set; }
    }
}