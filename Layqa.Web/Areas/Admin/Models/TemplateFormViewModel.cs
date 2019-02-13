using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Layqa.Web.Areas.Admin.Models
{
    public class TemplateFormViewModel
    {
        public int TemplateId { get; set; }
        public string Name { get; set; }
        public string AdminView { get; set; }
        public string FrontView { get; set; }
        public bool IsSection { get; set; }
        public bool Active { get; set; }
    }
}
