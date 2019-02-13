using System;
using System.Collections.Generic;

namespace Layqa.Entity
{
    public class Post : Entity
    {
        public Post()
        {
            Comment = new List<Comment>();
        }

        public int AuthorId { get; set; }

        public string Title { get; set; }
        public string Resumen { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public bool Active { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual AdmUser Author { get; set; }
        public virtual IList<Comment> Comment { get; set; }

        public void AddComment(Comment comment)
        {
            comment.PostId = this.Id;
            comment.Post = this;

            Comment.Add(comment);
        }

    }
}
