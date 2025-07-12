using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackIt.ViewModels
{
    public class AnswerViewModel
    {
        [Required]
        [AllowHtml]
        public string Content { get; set; }

        public int QuestionId { get; set; }
    }
}