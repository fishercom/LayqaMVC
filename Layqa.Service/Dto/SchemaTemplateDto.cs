using System;
using System.Collections.Generic;

namespace Layqa.Service.Dto
{
    public class SchemaTemplateDto
    {
        public int SchemaId { get; set; }
        public int TemplateId { get; set; }
        public string SchemaAlias { get; set; }
        public Nullable<int> Iterations { get; set; }
        public bool IsPage { get; set; }
        public bool Active { get; set; }

        public string TemplateName { get; set; }
        public string AdminView { get; set; }
        public string FrontView { get; set; }
    }
}
