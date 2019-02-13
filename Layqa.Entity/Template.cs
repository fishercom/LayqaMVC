using System;
using System.Collections.Generic;

namespace Layqa.Entity
{
    public class Template : Entity
    {
        public string Name { get; set; }
        public string AdminView { get; set; }
        public string FrontView { get; set; }
        public bool IsSection { get; set; }
        public bool Active { get; set; }

    }
}
