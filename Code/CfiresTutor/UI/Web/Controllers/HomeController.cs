using CfiresTutor.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : PublicController
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            SetPageTitle("一对一家教辅导");
            HtmlRenderContext.SetMetaKeyword("青岛家教,青岛家教网,青岛英语家教,青岛大学生家教,青岛兼职家教");
            HtmlRenderContext.SetMetaDescription("青岛龙腾家教是龙腾教育集团旗下品牌网站,致力于青岛一对一家教,青岛家教网,青岛兼职家教,青岛大学生家教信息咨询,让青岛找家教,青岛做家教,变得更加方便快捷.");
            return View();
        }

        /// <summary>
        /// 家教分类
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult _TeacherCategory()
        {
            return PartialView();
        }

        /// <summary>
        /// 快速登录注册
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult _QuickLogin()
        {
            return PartialView();
        }

        /// <summary>
        /// 签约教员服务
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult _ContractService()
        {
            return PartialView();
        }

        /// <summary>
        /// 帮助中心 
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult _Help()
        {
            return PartialView();
        }

        /// <summary>
        /// 最近成交家教记录
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult _LastestTeachRecord()
        {
            return PartialView();
        }

        /// <summary>
        /// 最新注册教员
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult _LastestTeacher()
        {
            return PartialView();
        }
    }
}