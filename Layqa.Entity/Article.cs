using System;
using System.Collections.Generic;

namespace Layqa.Entity
{
    public class Article : Entity
    {
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

        public virtual Article ArticleParent { get; set; }
        public virtual Schema Schema { get; set; }
        public virtual AdmUser Author { get; set; }

    }
}
