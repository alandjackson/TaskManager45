using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager45.Models;

namespace TaskManager45.Controllers
{
    public class TaskController : Controller
    {
        //
        // GET: /Task/

        public ActionResult Index()
        {
            ViewData["Tasks"] = new TaskRepository().GetTasks();
            return View();
        }

    }
}
