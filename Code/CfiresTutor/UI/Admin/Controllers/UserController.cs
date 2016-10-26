using CfiresTutor.BLL;
using CfiresTutor.Model;
using CfiresTutor.MVC;
using CfiresTutor.UI.Web.Models;
using CfiresTutor.Utilities;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace CfiresTutor.UI.Admin.Controllers
{
    public class UserController : PublicController
    {
        BaseUserBll _userBll = new BaseUserBll();

        /// <summary>
        /// 学员列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public ActionResult Students(int pageIndex = 1, int pageSize = 20, string keyword = null)
        {
            var userList = _userBll.GetPageList(pageIndex, pageSize, keyword, UserType.Student);
            return View(userList);
        }

        /// <summary>
        /// 教员列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public ActionResult Teachers(int pageIndex = 1, int pageSize = 20, string keyword = null)
        {
            var userList = _userBll.GetPageList(pageIndex, pageSize, keyword, UserType.Teacher);
            return View(userList);
        }

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

        /// <summary>
        /// 登录表单提交
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserLoginViewModel viewModel, string returnUrl)
        {
            Base_Teacher user = _userBll.GetByEmail(viewModel.Email);
            Login(user);

            if (user != null && SecurityHelper.DecryptAES(user.Password) == viewModel.Password)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("Validate", "用户名或密码错误");
                return View();
            }
        }

        #region private

        private void Login(Base_Teacher user)
        {
            var identity = new ClaimsIdentity("App");
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Email));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Role, user.UserType.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.GroupSid, user.UserType.ToString()));
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, identity);
        }

        /// <summary>
        /// 重定向
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}