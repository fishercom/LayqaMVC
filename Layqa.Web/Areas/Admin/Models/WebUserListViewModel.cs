using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Layqa.Web.Areas.Admin.Models
{
    public class WebUserListViewModel
    {
        public int UserId { get; set; }
        
        [DisplayName("Nombres")]
        public string FullName { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayName("Activo")]
        public bool Active { get; set; }
    }
}