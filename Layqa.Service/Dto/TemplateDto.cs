using System;
using System.Collections.Generic;

namespace Layqa.Service.Dto
{
    public class TemplateDto
    {
        public int TemplateId { get; set; }
        public string Name { get; set; }
        public string AdminView { get; set; }
        public string FrontView { get; set; }
        public bool IsSection { get; set; }
        public bool Active { get; set; }
    }
}
