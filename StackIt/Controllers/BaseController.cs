using Microsoft.AspNet.Identity;
using StackIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace StackIt.Controllers
{
    public class BaseController : Controller
    {
        protected StackItContext db = new StackItContext();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var notifications = db.Notifications
                                      .Where(n => n.UserId == userId && !n.IsRead)
                                      .OrderByDescending(n => n.CreatedAt)
                                      .ToList();

                ViewBag.Notifications = notifications;
                ViewBag.UnreadCount = notifications.Count;
            }

            base.OnActionExecuting(filterContext);
        }

    
    }
}