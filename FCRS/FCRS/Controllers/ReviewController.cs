using FCRS.Context;
using FCRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCRS.Controllers
{
    public class ReviewController : BaseController
    {
        // GET: Message
        public ActionResult Index()
        {
            var messages = db.Reviews.Include("User").ToList();
            messages.Reverse();
            return View(messages);
        }

        public ActionResult SendReview(string text)
        {
            if (Session["user_id"] != null && !String.IsNullOrEmpty(text))
            {
                User user = db.Users.Find(Session["user_id"]);
                Review msg = new Review();
                msg.User = user;
                msg.UserId = user.Id;
                msg.ReviewText = text;
                db.Reviews.Add(msg);
                db.SaveChanges();
                //   db.Messages.Include("User").ToList();
            }
            return RedirectToAction("Index");

        }


        public ActionResult DeleteReview(int? id)
        {
            var Message = db.Reviews.Find(id);
            if (Message != null)
            {
                db.Reviews.Remove(Message);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}