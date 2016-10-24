using CfiresTutor.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CfiresTutor.MVC
{
    public static class HtmlRenderContext
    {
        public static IHtmlRenderService CurrentHtmlRenderService { get; private set; }

        static HtmlRenderContext()
        {
            CurrentHtmlRenderService = new DefaultHtmlRenderService();
        }

        /// <summary>
        /// 设置【标题】
        /// </summary>
        /// <param name="title"></param>
        public static void SetPageTitle(string title)
        {
            HttpContext.Current.Items[MvcConst.PageTitleKey] = title;
        }

        /// <summary>
        /// 设置Meta标签【关键字】属性
        /// </summary>
        /// <param name="value"></param>
        public static void SetMetaKeyword(string value)
        {
            HttpContext.Current.Items[MvcConst.PageMetaKeywords] = value;
        }

        /// <summary>
        /// 设置Meta标签【描述】属性
        /// </summary>
        /// <param name="value"></param>
        public static void SetMetaDescription(string value)
        {
            HttpContext.Current.Items[MvcConst.PageMetaDescription] = value;
        }

        /// <summary>
        /// 渲染【页面标题】
        /// </summary>
        /// <returns></returns>
        public static IHtmlString RenderPageTitle()
        {
            string siteName = ConfigurationManager.AppSettings["siteName"];
            string title = HttpContext.Current.Items[MvcConst.PageTitleKey] as string;

            if (!string.IsNullOrWhiteSpace(siteName))
            {
                title = (string.IsNullOrWhiteSpace(title) ? "" : title + "--") + siteName;
            }

            return new MvcHtmlString(string.Format("<title>{0}</title>", title));
        }

        public static IHtmlString RenderMeta()
        {
            StringBuilder sb = new StringBuilder();
            if (HttpContext.Current.Items[MvcConst.PageMetaKeywords] != null)
            {
                sb.AppendLine("<meta name=\"Keywords\" content=\"" + HttpContext.Current.Items[MvcConst.PageMetaKeywords].ToString() + "\" />");
            }
            if (HttpContext.Current.Items[MvcConst.PageMetaDescription] != null)
            {
                sb.AppendLine("<meta name=\"Description\" content=\"" + HttpContext.Current.Items[MvcConst.PageMetaDescription].ToString() + "\" />");
            }
            return new MvcHtmlString(sb.ToString());
        }

        public static IHtmlString RenderScriptHtml(HtmlRenderLocation location)
        {
            return CurrentHtmlRenderService.ToHtml(location);
        }
    }
}
