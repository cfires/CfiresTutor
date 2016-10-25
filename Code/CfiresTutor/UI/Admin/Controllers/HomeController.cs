using CfiresTutor.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CfiresTutor.UI.Admin.Controllers
{
    [Authorize]
    public class HomeController : PublicController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}