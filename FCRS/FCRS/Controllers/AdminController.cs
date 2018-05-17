using FCRS.Context;
using FCRS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FCRS.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
       

        //public ActionResult ListOfUsers(string search)
        //{
        //    // List<User> user = db.Users.ToList();
        //    var user = from u in db.Users
        //               select u;

        //    if(!String.IsNullOrEmpty(search))
        //    {
        //        user = user.Where(u => u.Firstname.Contains(search));
        //    }

        //    return View(db.Users.ToList());
        //}
        public ActionResult ListOfUsers(string search)
        {
            var usr = db.Users;
            List<User> users;

            if (!String.IsNullOrEmpty(search))
            {
                users = usr.Where(s =>
                    s.Firstname.Contains(search) ||
                    s.Lastname.Contains(search))
                    .ToList();
            }
            else
            {
                users = usr.ToList();
            }
            return View(users);
        }


        public ActionResult Reservations (string search)
        {
            var Reservations = db.Reservationns.Include("User");
                List<Reservation> reservations;
                 
            if(!String.IsNullOrEmpty(search))
            {
                reservations = Reservations.Include("User").Where(s =>                                    ///Where(s =>
                               s.User.Firstname.Contains(search) || 
                               s.User.Lastname.Contains(search) ||
                               s.Status.Contains(search))
                                .ToList();


            }
            else
            {
                reservations = Reservations.ToList();
            }

            reservations.Reverse();
            return View(reservations);
        }

        public ActionResult Delete(int? id)
        {
            var Reservation = db.Reservationns.Find(id);
            if (Reservation != null)
            {
                db.Reservationns.Remove(Reservation);
                db.SaveChanges();
            }
            return RedirectToAction("Reservations");
        }

        public ActionResult SetStatus(int? id, string text)
        {
            var r = db.Reservationns.Find(id);
            if (r != null && text != null)
            {
                r.Status = text;
                db.SaveChanges();
            }
            return RedirectToAction("Reservations");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User users = db.Users.Find(id);


            if (users == null)
            {
                return HttpNotFound();
            }

            return View(users);
        }


        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(user);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Firstname,Lastname,DateOfBirth,Email,Password,ConfirmPassword,Admin")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(user).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(user);
        //}
        public ActionResult PoslijeLogin()
        {
            return View();
        }



        public ActionResult Edit()
        {
            int? user_id = Session["user_id"] as int?;

            if (user_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(user_id);
            if (user == null)
            {
                return HttpNotFound();
            }           
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( User user)
        {
            if (ModelState.IsValid)
            {
                User toSave = db.Users.Find(user.Id);
                db.Entry(toSave).CurrentValues.SetValues(user);
                toSave.Admin = user.Admin;
                db.SaveChanges();
                return RedirectToAction("PoslijeLogin");
            }
          
            return View(user);
        }

        //                    EDIT USER
        public ActionResult EditUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }             
            return View(user);
        }

        





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser([Bind(Include = "Id,Firstname,Lastname,DateOfBirth,Email,Phone,Address,Password,ConfirmPassword,Admin")] User user)
        {
            if (ModelState.IsValid)
            {
                User toSave = db.Users.Find(user.Id);
                db.Entry(toSave).CurrentValues.SetValues(user);
                db.Entry(toSave).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListOfUsers");
            }            
            return View(user);
        }

        public ActionResult DeleteUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            if (user == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("ListOfUsers");
        }

    }
}