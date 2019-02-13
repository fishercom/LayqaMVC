using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Layqa.Web.Areas.Admin.Models
{
    public class PostFormViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Resumen { get; set; }
        public string Description { get; set; }

        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; }
        public bool Active { get; set; }
        public DateTime RegisterDate { get; set; }
    }

}