using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CfiresTutor.UI.Web.Controllers
{
    /// <summary>
    /// 帮助说明
    /// </summary>
    public class HelpController : Controller
    {
        [HttpGet]
        public ActionResult Index(string viewName = "_TeacherNotice")
        {
            return View(viewName);
        }
    }
}