using FCRS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCRS.Controllers
{
    public class BaseController : Controller
    {
        protected FCRSContext db = new FCRSContext();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        ViewData["user"] = db.Users.Find(Session["user_id"]);
           
        }
    }
}