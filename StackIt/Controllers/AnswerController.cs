using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using StackIt.Models;

namespace StackIt.Controllers
{
    public class AnswerController : BaseController
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int QuestionId, string Content)
        {
            if (string.IsNullOrWhiteSpace(Content))
            {
                TempData["Error"] = "Answer cannot be empty.";
                return RedirectToAction("Details", "Question", new { id = QuestionId });
            }

            var answer = new Answer
            {
                Content = Content,
                QuestionId = QuestionId,
                UserId = User.Identity.GetUserId(),
                CreatedAt = DateTime.Now
            };

            db.Answers.Add(answer);
            db.SaveChanges();

            return RedirectToAction("Details", "Question", new { id = QuestionId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAjax(int QuestionId, string Content)
        {
            if (string.IsNullOrWhiteSpace(Content))
            {
                Response.StatusCode = 400;
                return new ContentResult { Content = "Answer cannot be empty." };
            }

            var answer = new Answer
            {
                Content = Content,
                QuestionId = QuestionId,
                UserId = User.Identity.GetUserId(),
                CreatedAt = DateTime.Now
            };

            db.Answers.Add(answer);
            db.SaveChanges();

            // Include User when returning answer list
            var answers = db.Answers
                .Where(a => a.QuestionId == QuestionId)
                .OrderByDescending(a => a.CreatedAt)
                .ToList();

            // Ensure User is eager loaded (avoids null in partial view)
            foreach (var a in answers)
            {
                a.User = db.Users.Find(a.UserId);
            }

            return PartialView("~/Views/Answer/_AnswerListPartial.cshtml", answers);
        }

    }
}
