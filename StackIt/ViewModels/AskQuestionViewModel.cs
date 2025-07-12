using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackIt.ViewModels
{
    public class AskQuestionViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "Tags")]
        public List<int> SelectedTagIds { get; set; }

        public MultiSelectList TagsList { get; set; }
    }
}