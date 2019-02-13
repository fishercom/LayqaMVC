using System;
using System.Collections.Generic;

namespace Layqa.Service.Dto
{
    public class PostDto
    {
        public int PostId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Resumen { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public bool Active { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
