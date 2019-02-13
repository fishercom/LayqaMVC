using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Layqa.Web.Areas.Admin.Models
{
    public class WebUserFormViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime RegisterDate { get; set; }

        public string AccountId { get; set; } //Identity integration

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}