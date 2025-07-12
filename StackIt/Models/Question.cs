using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackIt.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<QuestionTag> QuestionTags { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}