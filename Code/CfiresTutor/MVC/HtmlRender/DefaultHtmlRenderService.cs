using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

namespace CfiresTutor.MVC
{
    public class DefaultHtmlRenderService : IHtmlRenderService
    {
        static string contentUrl = ResolveUrl(ConfigurationManager.AppSettings["contentUrl"] ?? "~/Content");
        static string currentAssemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        #region 处理添加js、css的逻辑方法
        public void AddCustomTag(string tagName, object attributes, bool selfClosing = true, HtmlRenderLocation location = HtmlRenderLocation.Header, HtmlRenderPriority priority = HtmlRenderPriority.Normal, string ifExpressionFormat = "")
        {
            TagBuilder tb = new TagBuilder(tagName);
            if (attributes != null)
                tb.MergeAttributes(new RouteValueDictionary(attributes), true);

            var maps = GetScripts();
            maps[tagName + maps.Count] = new HtmlRenderTag()
            {
                Location = location,
                Priority = priority,
                Type = HtmlRenderType.Custom,
                IFExpressionFormat = ifExpressionFormat,
                SelfClosing = selfClosing,
                TagBuilder = tb
            };
        }

        public void AddJavascript(string url, HtmlRenderLocation location = HtmlRenderLocation.Header, HtmlRenderPriority priority = HtmlRenderPriority.Normal, string version = "", string ifExpression = "")
        {
            Add(HtmlRenderType.Js, url, location, priority, version, ifExpression);
        }

        public void AddCss(string url, HtmlRenderLocation location = HtmlRenderLocation.Header, HtmlRenderPriority priority = HtmlRenderPriority.Normal, string version = "", string ifExpression = "")
        {
            Add(HtmlRenderType.Css, url, location, priority, version, ifExpression);
        }

        private void Add(HtmlRenderType type, string url, HtmlRenderLocation location, HtmlRenderPriority priority, string version, string ifExpressionFormat)
        {
            var maps = GetScripts();

            maps[url.ToLower()] = new HtmlRenderTag()
            {
                Location = location,
                Priority = priority,
                Type = type,
                Url = url,
                IFExpressionFormat = ifExpressionFormat,
                Version = string.IsNullOrWhiteSpace(version) ? currentAssemblyVersion : version
            };
        }

        private IDictionary GetScripts()
        {
            var maps = HttpContext.Current.Items[MvcConst.PageScriptsKey] as OrderedDictionary;
            if (maps == null)
            {
                maps = new OrderedDictionary();
                HttpContext.Current.Items[MvcConst.PageScriptsKey] = maps;
            }
            return maps;
        }
        #endregion


        #region 静态站
        public string GetContentUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return string.Empty;

            if (url.StartsWith("~"))
                return ResolveUrl(url);

            if (url.StartsWith("http://", StringComparison.CurrentCultureIgnoreCase) || url.StartsWith("https://", StringComparison.CurrentCultureIgnoreCase))
                return url;

            return contentUrl + (url.StartsWith("/") ? string.Empty : "/") + url;
        }

        private static string ResolveUrl(string relativeUrl)
        {
            if (relativeUrl == null)
                return null;

            if (!relativeUrl.StartsWith("~"))
                return relativeUrl;

            return VirtualPathUtility.ToAbsolute(relativeUrl);
        }
        #endregion

        private StringBuilder ProcessRender(IDictionary maps, HtmlRenderLocation location)
        {
            StringBuilder sb = new StringBuilder();
            maps.Values.Cast<HtmlRenderTag>()
                .Where(n => n.Location == location)
                    .OrderBy(n => n.Priority).ToList()
                        .ForEach(n =>
                        {
                            n.Url = GetContentUrl(n.Url);
                            sb.AppendLine(n.Tag);
                        });
            return sb;
        }

        public IHtmlString ToHtml(HtmlRenderLocation location = HtmlRenderLocation.Header)
        {
            var maps = GetScripts();
            StringBuilder sb = new StringBuilder();
            if (maps.Count > 0)
            {
                sb.Append(ProcessRender(maps, location));
            }
            return new MvcHtmlString(sb.ToString());
        }
    }
}
