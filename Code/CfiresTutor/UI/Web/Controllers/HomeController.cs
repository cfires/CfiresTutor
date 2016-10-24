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
        public ActionResult Index()
        {
            SetPageTitle("一对一家教辅导");
            HtmlRenderContext.SetMetaKeyword("青岛家教,青岛家教网,青岛英语家教,青岛大学生家教,青岛兼职家教");
            HtmlRenderContext.SetMetaDescription("青岛龙腾家教是龙腾教育集团旗下品牌网站,致力于青岛一对一家教,青岛家教网,青岛兼职家教,青岛大学生家教信息咨询,让青岛找家教,青岛做家教,变得更加方便快捷.");
            return View();
        }
    }
}