using FCRS.Context;
using FCRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCRS.Controllers
{
    public class InfoController : BaseController
    {
        // GET: Message
        public ActionResult Index()
        {
            var messages = db.Infos.Include("User").ToList();
            messages.Reverse();
            return View(messages);
        }

        public ActionResult SendReview(string text)
        {
            if (Session["user_id"] != null && !String.IsNullOrEmpty(text))
            {
                User user = db.Users.Find(Session["user_id"]);
                Info msg = new Info();
                msg.User = user;
                msg.UserId = user.Id;
                msg.InfoText = text;
                db.Infos.Add(msg);
                db.SaveChanges();
                //   db.Messages.Include("User").ToList();
            }
            return RedirectToAction("Index");

        }


        public ActionResult DeleteMessage(int? id)
        {
            var Message = db.Infos.Find(id);
            if (Message != null)
            {
                db.Infos.Remove(Message);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}