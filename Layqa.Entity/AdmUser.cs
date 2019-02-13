using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layqa.Entity
{
    public class AdmUser : Entity
    {
        public int AdmProfileId { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime RegisterDate { get; set; }

        public string AccountId { get; set; } //Identity integration

        public virtual AdmProfile AdmProfile { get; set; }
        public virtual ICollection<Article> Article { get; set; }
        public virtual ICollection<Post> Post { get; set; }

    }
}
