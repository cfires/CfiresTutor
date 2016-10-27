using CfiresTutor.BLL;
using CfiresTutor.Model;
using CfiresTutor.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using Microsoft.Owin.Security;

namespace CfiresTutor.MVC
{
    /// <summary>
    ///  Controller基类
    /// </summary>
    public class PublicController : Controller
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PublicController()
            : base()
        {
            this.ValidateRequest = false;
        }

        protected IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        /// <summary>
        /// 当前用户
        /// </summary>
        public Base_User CurrentUser
        {
            get
            {
                var user = AuthenticationManager.User;

                ExceptionHelper.IsNull(user, "获取不到登录票据！");

                if (!user.Identity.IsAuthenticated)
                    return null;

                Base_User userInfo;

                var useridClaimType = user.FindFirst(ClaimTypes.NameIdentifier);
                var usertypeClaimType = user.FindFirst(ClaimTypes.GroupSid);

                UserType ut = EnumHelper.Parse<UserType>(usertypeClaimType.Value);
                int userID = int.Parse(useridClaimType.Value);

                Base_UserBll _userService = new Base_UserBll();

                switch (ut)
                {
                    case UserType.Student:
                    case UserType.Teacher:
                    default:
                        userInfo = _userService.Get(userID);
                        break;
                }

                ExceptionHelper.IsNull(userInfo, "获取不到登录用户！");

                return userInfo;
            }
        }

        /// <summary>
        /// 设置页面title
        /// </summary>
        /// <param name="title"></param>
        protected virtual void SetPageTitle(string title = "")
        {
            HtmlRenderContext.SetPageTitle(title);
        }
    }
}
