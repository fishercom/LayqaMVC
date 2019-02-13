using System;
using System.Collections.Generic;

namespace Layqa.Service.Dto
{
    public class SchemaDto
    {
        public int SchemaId { get; set; }
        public Nullable<int> SchemaParentId { get; set; }
        //public int SectionId { get; set; }
        public int TemplateId { get; set; }

        public Nullable<int> Iterations { get; set; }
        public short Position { get; set; }
        public bool IsPage { get; set; }
        public string Alias { get; set; }
        public bool Active { get; set; }

        //public SectionDto Section { get; set; }
        public TemplateDto Template { get; set; }
    }
}
