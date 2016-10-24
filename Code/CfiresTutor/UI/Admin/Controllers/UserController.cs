using CfiresTutor.BLL;
using CfiresTutor.Model;
using CfiresTutor.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CfiresTutor.UI.Admin.Controllers
{
    public class UserController : Controller
    {
        UserService _userService = new UserService();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserLoginViewModel viewModel, string returnUrl)
        {
            Base_User user = _userService.GetByEmail(viewModel.Email);
            return View();
        }
    }
}