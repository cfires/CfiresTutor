using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CfiresTutor.MVC
{
    public enum HtmlRenderLocation
    {
        Header = 0,
        Footer = 1
    }

    public enum HtmlRenderPriority
    {
        High = 0,
        Normal = 1,
        Low = 2
    }

    internal enum HtmlRenderType
    {
        Js = 0,
        Css = 1,
        Custom = 2
    }
}
