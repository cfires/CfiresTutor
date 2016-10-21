using CfiresTutor.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CfiresTutor.UI.Web.Controllers
{
    public class StudentController : PublicController
    {
        // GET: Students
        public ActionResult Index()
        {
            return View();
        }
    }
}