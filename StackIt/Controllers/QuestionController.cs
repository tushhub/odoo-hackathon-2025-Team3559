using Microsoft.AspNet.Identity;
using StackIt.Models;
using StackIt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StackIt.Controllers
{
    public class QuestionController : BaseController
    {
        private StackItContext db = new StackItContext();

        [HttpGet]
        public ActionResult Ask()
        {
            var viewModel = new AskQuestionViewModel
            {
                TagsList = new MultiSelectList(db.Tags.ToList(), "Id", "Name")
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AskQuestion(AskQuestionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var question = new Question
                {
                    Title = model.Title,
                    Description = model.Description,
                    CreatedAt = DateTime.Now,
                    UserId = User.Identity.GetUserId() // or however you track user
                };

                // Save tags
                if (model.SelectedTagIds != null)
                {
                    question.QuestionTags = model.SelectedTagIds.Select(tagId => new QuestionTag
                    {
                        TagId = tagId
                    }).ToList();
                }
                System.Diagnostics.Debug.WriteLine("Saving question: " + model.Title);
                System.Diagnostics.Debug.WriteLine("Description: " + model.Description);

                db.Questions.Add(question);
                db.SaveChanges();

                // Redirect to Details page of the newly created question
                return RedirectToAction("Details", new { id = question.Id });
            }

            // Re-populate TagsList if model state is invalid
            model.TagsList = new MultiSelectList(db.Tags.ToList(), "Id", "Name", model.SelectedTagIds);
            return View("Ask", model);
        }


        //public ActionResult Details(int id)
        //{
        //    var question = db.Questions
        //                      .Include("User")
        //                     .Include("Answers")
        //                     .Include("QuestionTags.Tag")
        //                     .FirstOrDefault(q => q.Id == id);

        //    if (question == null) return HttpNotFound();

        //    return View(question);
        //}

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var question = db.Questions
                .Include("User") // Use string-based Include for EF6
                .Include("Answers.User") // Use string-based Include for nested properties
                .Include("QuestionTags.Tag") // Use string-based Include for related entities
                .FirstOrDefault(q => q.Id == id.Value);

            if (question == null) return HttpNotFound();

            return View(question);
        }


        public ActionResult Index()
        {
            var questions = db.Questions
                .Include("User")
                .Include("Answers")
                .Include("QuestionTags.Tag")
                .OrderByDescending(q => q.CreatedAt)
                .ToList();

            return View(questions);
        }


        //// GET: Question
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}