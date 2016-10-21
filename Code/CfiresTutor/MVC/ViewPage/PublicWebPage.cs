using CfiresTutor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CfiresTutor.MVC
{
    public abstract class PublicWebPage : PublicWebPage<object>
    { }

    public abstract class PublicWebPage<TModel> : WebViewPage<TModel>
    {

        public Base_User CurrentUser
        {
            get
            {
                return ((PublicController)this.ViewContext.Controller).CurrentUser;
            }
        }
    }
}
