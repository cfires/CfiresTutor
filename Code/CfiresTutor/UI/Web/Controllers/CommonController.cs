using CfiresTutor.Utilities;
using CfiresTutor.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CfiresTutor.UI.Web.Controllers
{
    /// <summary>
    /// 公用
    /// </summary>
    public class CommonController : PublicController
    {
        #region 验证码

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowCaptcha()
        {
            var captcha = CaptchaUtility.Generate(6);
            Session["captcha"] = captcha;
            byte[] buff = CaptchaUtility.Draw(captcha);
            return File(buff, "image/jpeg");
        }

        #endregion
    }
}