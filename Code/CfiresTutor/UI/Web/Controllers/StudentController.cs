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
        /// <summary>
        /// 学员库
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 加入学员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Join()
        {
            return View();
        }
    }
}