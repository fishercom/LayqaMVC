using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Layqa.Web.Areas.Admin.Models
{
    public class PostListViewModel
    {
        public int PostId { get; set; }

        [DisplayName("Título")]
        public string Title { get; set; }

        [DisplayName("Estado")]
        public string Status { get; set; }

        [DisplayName("Fecha Registro")]
        public DateTime RegisterDate { get; set; }
    }
}