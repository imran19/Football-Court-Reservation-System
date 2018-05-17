using FCRS.Context;
using FCRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCRS.Controllers
{
    public class MessageController : BaseController
    {
        // GET: Message
        public ActionResult Index()
        {
            var messages = db.Messages.Include("User").ToList();
            messages.Reverse();
            return View(messages);
        }

        public ActionResult SendMessage(string text)
        {
            if (Session["user_id"] != null && !String.IsNullOrEmpty(text))
            {
                User user = db.Users.Find(Session["user_id"]);
                Message msg = new Message();
                msg.User = user;
                msg.UserId = user.Id;
                msg.MessageText = text;
                db.Messages.Add(msg);
                db.SaveChanges();
             //   db.Messages.Include("User").ToList();
            }
            return RedirectToAction("Index");
            
        }

        
        public ActionResult DeleteMessage(int? id)
        {
            var Message = db.Messages.Find(id);
            if (Message != null)
            {
                db.Messages.Remove(Message);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}