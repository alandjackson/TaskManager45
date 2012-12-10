using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskManager45.Models;

namespace TaskManager45.Controllers
{
    public class TaskController : Controller
    {
        //
        // GET: /Task/

        public ActionResult Index(string taskType)
        {
            ViewData["Tasks"] = new TaskRepository().GetTasksByType(taskType);
            return View();
        }

        [HttpPost]
        public ActionResult Create(string description)
        {
            try
            {
                new TaskRepository().CreateTask(description);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                Response.StatusDescription = e.Message;
            }

            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                new TaskRepository().DeleteTask(id);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                Response.StatusDescription = e.Message;
            }
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult UpdateCompleted(int id)
        {
            try
            {
                var db = new TaskRepository();
                var isCompleted = !string.IsNullOrWhiteSpace(Request.Params["task-row-" + id + "-completed"]);
                var task = db.GetTask(id);
                task.CompletedAt = isCompleted ? (DateTime?)DateTime.Now : (DateTime?)null;
                db.UpdateTask(task);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                Response.StatusDescription = e.Message;
            }
            return new EmptyResult();
        }

        public ActionResult Today()
        {
            return View();
        }

        public ActionResult History()
        {
            return View();
        }

    }
}
