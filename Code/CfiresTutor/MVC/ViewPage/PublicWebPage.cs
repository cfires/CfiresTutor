using CfiresTutor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CfiresTutor.MVC
{
    public abstract class PublicWebPage : PublicWebPage<object>
    { }

    public abstract class PublicWebPage<TModel> : WebViewPage<TModel>
    {

        /// <summary>
        /// 当前用户
        /// </summary>
        public Base_User CurrentUser
        {
            get
            {
                return ((PublicController)this.ViewContext.Controller).CurrentUser;
            }
        }

        /// <summary>
        /// 渲染页面标题
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public virtual IHtmlString _RenderTitle(string title = "")
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                HtmlRenderContext.SetPageTitle(title);
            }

            return HtmlRenderContext.RenderPageTitle();
        }

        /// <summary>
        /// 渲染Meta标签
        /// </summary>
        /// <returns></returns>
        public virtual IHtmlString _RenderMeta()
        {
            return HtmlRenderContext.RenderMeta();
        }

        public virtual IHtmlString _RenderHeaderScripts(Action<IHtmlRenderService> action)
        {
            if (action != null)
                action(HtmlRenderContext.CurrentHtmlRenderService);
            return HtmlRenderContext.RenderScriptHtml(HtmlRenderLocation.Header);
        }

        public virtual IHtmlString _RenderFooterScripts(Action<IHtmlRenderService> action)
        {
            if (action != null)
                action(HtmlRenderContext.CurrentHtmlRenderService);
            return HtmlRenderContext.RenderScriptHtml(HtmlRenderLocation.Footer);
        }

    }
}
