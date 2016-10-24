using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CfiresTutor.MVC
{
    public interface IHtmlRenderService
    {
        void AddCustomTag(string tagName, object attributes, bool selfClosing = true, HtmlRenderLocation location = HtmlRenderLocation.Header, HtmlRenderPriority priority = HtmlRenderPriority.Normal, string ifExpression = "");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="location"></param>
        /// <param name="priority"></param>
        /// <param name="version"></param>
        /// <param name="ifExpression"><!--[if (gte IE 9)|!(IE)]><!-->{0}<!--<![endif]-->，<!--[if lt IE 9]>{0}<![endif]--></param>
        void AddJavascript(string url, HtmlRenderLocation location = HtmlRenderLocation.Header, HtmlRenderPriority priority = HtmlRenderPriority.Normal, string version = "", string ifExpression = "");
        void AddCss(string url, HtmlRenderLocation location = HtmlRenderLocation.Header, HtmlRenderPriority priority = HtmlRenderPriority.Normal, string version = "", string ifExpression = "");
        string GetContentUrl(string url);
        IHtmlString ToHtml(HtmlRenderLocation location = HtmlRenderLocation.Header);
    }
}
