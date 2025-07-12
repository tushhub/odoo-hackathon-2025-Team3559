using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackIt.Models
{
    public class Answer
    {
        public int Id { get; set; }

        [AllowHtml]
        public string Content { get; set; }

        public bool IsAccepted { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}