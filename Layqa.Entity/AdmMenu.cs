﻿using System;
using System.Collections.Generic;

namespace Layqa.Entity
{
    public class AdmMenu : Entity
    {
        public Nullable<int> MenuParentId { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Params { get; set; }
        public string IconCss { get; set; }
        public int Position { get; set; }
        public bool Active { get; set; }

        public virtual AdmMenu MenuParent { get; set; }

    }
}
