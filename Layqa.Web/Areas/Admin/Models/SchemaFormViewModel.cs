using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Layqa.Web.Areas.Admin.Models
{
    public class SchemaFormViewModel
    {
        public int SchemaId { get; set; }
        public Nullable<int> SchemaParentId { get; set; }
        public int SectionId { get; set; }
        public int TemplateId { get; set; }

        public Nullable<int> Iterations { get; set; }
        public short Position { get; set; }
        public bool IsPage { get; set; }
        public string Alias { get; set; }
        public bool Active { get; set; }
    }
}
