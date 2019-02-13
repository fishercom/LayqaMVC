using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Layqa.Web.Areas.Admin.Models
{
    public class TemplateListViewModel
    {
        public int TemplateId { get; set; }
        
        [DisplayName("Nombre")]
        public string Name { get; set; }
        
        [DisplayName("Vista Admin")]
        public string AdminView { get; set; }
        
        [DisplayName("Vista Pública")]
        public string FrontView { get; set; }

        [DisplayName("Activo")]
        public bool Active { get; set; }
    }
}
