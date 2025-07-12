using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackIt.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public bool IsUpvote { get; set; }
    }
}