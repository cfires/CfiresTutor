using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CfiresTutor.MVC
{
    internal class HtmlRenderTag
    {
        internal string Url { get; set; }
        internal HtmlRenderLocation Location { get; set; }
        internal HtmlRenderPriority Priority { get; set; }
        internal string Version { get; set; }
        internal string IFExpressionFormat { get; set; }
        internal HtmlRenderType Type { get; set; }
        internal TagBuilder TagBuilder { get; set; }
        internal bool SelfClosing { get; set; }
        const string cssFormat = "<link type=\"text/css\" rel=\"stylesheet\" href=\"{0}\" />";
        const string jsFormat = "<script type=\"text/javascript\" src=\"{0}\" ></script>";
        internal string Tag
        {
            get
            {
                string htmTag = Type == HtmlRenderType.Custom ?
                    (SelfClosing ? TagBuilder.ToString(TagRenderMode.SelfClosing) : (TagBuilder.ToString(TagRenderMode.StartTag) + TagBuilder.ToString(TagRenderMode.EndTag)))
                        : string.Format(Type == HtmlRenderType.Css ? cssFormat : jsFormat, this.Url/*, this.Version*/);
                if (string.IsNullOrWhiteSpace(IFExpressionFormat))
                    return htmTag;
                return string.Format(IFExpressionFormat, htmTag);
            }
        }
    }
}
