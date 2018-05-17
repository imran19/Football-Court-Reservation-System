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
    public class UsersController : BaseController
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(User account)
        {
            if (ModelState.IsValid)
            {
                using (FCRSContext db = new FCRSContext())

                {
                    account = db.Users.Add(account);
                    db.SaveChanges();
                    Session["user_id"] = account.Id;
                }

                ModelState.Clear();
                // ViewBag.Message = account.Firstname + "Successfully registered.";
                return RedirectToAction("PoslijeLogin");
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            user = db.Users
                .Where(u => u.Email == user.Email && u.Password == user.Password)
                .FirstOrDefault();
            if (user != null)
            {
                Session["user_id"] = user.Id;
                if (user.Admin == true)
                    return RedirectToAction("PoslijeLogin", "Admin");
                else
                    return RedirectToAction("PoslijeLogin");
            }
            return View();
        }
        public ActionResult PoslijeLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logoff()
        {
            Session["user_id"] = null;
            return RedirectToAction("Index", "Home");
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
        public ActionResult Edit([Bind(Include = "Id,Firstname,Lastname,DateOfBirth,Email,Phone,Address,Password,ConfirmPassword")] User user)
        {
            if (ModelState.IsValid)
            {
                User toSave = db.Users.Find(user.Id);
                db.Entry(toSave).CurrentValues.SetValues(user);
                db.Entry(toSave).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PoslijeLogin");
            }

            return View(user);
        }


        public ActionResult Reservation()
        {

            int? user_id = Session["user_id"] as int?;
            if (user_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View();
        }

        public ActionResult ReservationSuccess()
        {
            return View();
        }


        //           LIST OF RESERVATIONS

        //    public ActionResult ListOfReservations()
        //{
        //    int? user_id = Session["user_id"] as int?;
        //    List<Reservation> reservation = db.Reservationns
                
        //        .Where(l => l.UserId == user_id)
        //        .ToList();

        //    return View(reservation);
        //}

            public ActionResult ListOfReservations(string search)
        {
            int? user_id = Session["user_id"] as int?;
            var Reservations = db.Reservationns;
            List<Reservation> reservations;

            if(!String.IsNullOrEmpty(search))
            {
                reservations = Reservations.Where(l => l.UserId == user_id &&
               l.Status.Contains(search))
               .ToList();
                
            }
            else
            {
                reservations = Reservations.Where(l => l.UserId == user_id).ToList();
            }
            return View(reservations);
        }




        [HttpPost]
        public ActionResult Reservation(Reservation req)
        {

            int? user_id = Session["user_id"] as int?;
            if (user_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                
                req.UserId = user_id ?? -1;
                req.Status = "Pending";
                db.Reservationns.Add(req);
                db.SaveChanges();

                ModelState.Clear();
                // ViewBag.Message = account.Firstname + "Successfully registered.";
                return RedirectToAction("ReservationSuccess");
            }
            return View();

        }


    }
}

            
   