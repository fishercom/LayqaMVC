using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Layqa.Web.Models
{
    public class ContactFormViewModel
    {

        public int ContactId { get; set; }

        public string ToEmail { get; set; }
        public string Subject { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }

    }

}