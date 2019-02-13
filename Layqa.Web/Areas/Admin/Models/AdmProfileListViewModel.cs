using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Layqa.Web.Areas.Admin.Models
{
    public class AdmProfileListViewModel
    {
        public int AdmProfileId { get; set; }

        [DisplayName("Nombre")]
        public string Name { get; set; }
    }
}