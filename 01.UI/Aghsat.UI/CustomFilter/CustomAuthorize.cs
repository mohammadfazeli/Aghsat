using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aghsat.UI.CustomFilter
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            var x = httpContext.User.Identity.Name;
            var y = httpContext.User.Identity.IsAuthenticated;
            var z = httpContext.User.IsInRole(Roles);
            return true;
            //return base.AuthorizeCore(httpContext);
        }
    }
}