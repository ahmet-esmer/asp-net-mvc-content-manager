using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroOptik.WebUI.Infrastructure.Authorization
{
    public class AdminAuthorization : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

       
            if (filterContext.HttpContext.Request.Cookies["MicroOptikAdmin"] == null)
                filterContext.HttpContext.Response.Redirect("~/Admin/Login/");

           // base.OnAuthorization(filterContext);
        }


    }
}