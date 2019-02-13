using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Layqa.Web.Areas.Admin.Models
{
    public class SchemaListViewModel
    {
        public int SchemaId { get; set; }
        public int TemplateId { get; set; }

        [DisplayName("Repetir")]
        public Nullable<int> Iterations { get; set; }
        
        [DisplayName("Es Página")]
        public bool IsPage { get; set; }

        [DisplayName("Activo")]
        public bool Active { get; set; }

        [DisplayName("Plantilla")]
        public string TemplateName { get; set; }

        public string AdminView { get; set; }
        public string FrontView { get; set; }
    }
}
