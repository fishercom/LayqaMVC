using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Layqa.Web.Areas.Admin.Models
{
    public class ArticleListViewModel
    {
        public int ArticleId { get; set; }
        public Nullable<int> ArticleParentId { get; set; }
        public int SchemaId { get; set; }

        [DisplayName("Título")]
        public string Title { get; set; }
        
        [DisplayName("Estado")]
        public string Status { get; set; }

        [DisplayName("Fecha Registro")]
        public DateTime RegisterDate { get; set; }
    }
}