using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FCRS.Models;

using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using DHTMLX.Common;
using FCRS.Controllers;
using System.Net;

namespace mySchedulerApp.Controllers
{
    public class BasicSchedulerController : BaseController
    {
        public ActionResult Index()
        {
            var scheduler = new DHXScheduler(this); //initializes dhtmlxScheduler
            scheduler.Height = 500;
            scheduler.LoadData = true;// allows loading data
            scheduler.EnableDataprocessor = true;// enables DataProcessor in order to enable implementation CRUD operations
            return View(scheduler);
        }

        public ActionResult Data()
        {//events for loading to scheduler
            return new SchedulerAjaxData(new SampleDataContext().Events);
        }




        public ActionResult Save(Event updatedEvent, FormCollection formData)
        {

            int? user_id = Session["user_id"] as int?;

            if (user_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var action = new DataAction(formData);
            var context = new SampleDataContext();
            

            try
            {
                switch (action.Type)
                {
                    case DataActionTypes.Insert: // your Insert logic
                        context.Events.InsertOnSubmit(updatedEvent);
                        break;
                    case DataActionTypes.Delete: // your Delete logic
                        updatedEvent = context.Events.SingleOrDefault(ev => ev.id == updatedEvent.id);
                        context.Events.DeleteOnSubmit(updatedEvent);
                        break;
                    default:// "update" // your Update logic
                        updatedEvent = context.Events.SingleOrDefault(
                        ev => ev.id == updatedEvent.id);
                        UpdateModel(updatedEvent);
                        break;
                }
                context.SubmitChanges();
                action.TargetId = updatedEvent.id;
            }
            catch (Exception a)
            {
                action.Type = DataActionTypes.Error;
            }
            return (new AjaxSaveResponse(action));
        }
    }
}