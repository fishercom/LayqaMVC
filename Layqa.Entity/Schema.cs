using System;
using System.Collections.Generic;

namespace Layqa.Entity
{
    public class Schema : Entity
    {
        public Nullable<int> SchemaParentId { get; set; }
        //public int SectionId { get; set; }
        public int TemplateId { get; set; }

        public Nullable<int> Iterations { get; set; }
        public short Position { get; set; }
        public bool IsPage { get; set; }
        public string Alias { get; set; }
        public bool Active { get; set; }

        public virtual Schema SchemaParent { get; set; }
        public virtual Template Template { get; set; }

    }
}
