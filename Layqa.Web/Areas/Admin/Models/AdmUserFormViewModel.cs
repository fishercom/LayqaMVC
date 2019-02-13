using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Layqa.Web.Areas.Admin.Models
{
    public class AdmUserFormViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        public bool Active { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime RegisterDate { get; set; }

        public string AccountId { get; set; } //Identity integration
        public int AdmProfileId { get; set; } //Custom security

        public string Password { get; set; }

        [Display(Name = "Confirmar Password")]
        public string ConfirmPassword { get; set; }

    }
}