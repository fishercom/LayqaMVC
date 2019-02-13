using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layqa.Entity
{
    public class WebUser : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime RegisterDate { get; set; }

        public string AccountId { get; set; } //Identity integration

        public virtual ICollection<Comment> Comment { get; set; }

    }
}
