using System;
using System.Collections.Generic;

namespace Layqa.Entity
{
    public class Comment : Entity
    {
        public int PostId { get; set; }
        public int UserId { get; set; }

        public string Message { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual Post Post { get; set; }
        public virtual WebUser WebUser { get; set; }
    }
}
