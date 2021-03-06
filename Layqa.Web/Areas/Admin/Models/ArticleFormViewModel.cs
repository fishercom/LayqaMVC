﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Layqa.Web.Areas.Admin.Models
{
    public class ArticleFormViewModel
    {
        public int ArticleId { get; set; }
        public Nullable<int> ArticleParentId { get; set; }
        public int SchemaId { get; set; }
        public int AuthorId { get; set; }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Resumen { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
        public string XmlParams { get; set; }
        public bool ShowInHome { get; set; }
        public Nullable<DateTime> PublishDate { get; set; }
        public string StaticUrl { get; set; }
        public int Position { get; set; }
        public bool Active { get; set; }
        public DateTime RegisterDate { get; set; }

    }

}