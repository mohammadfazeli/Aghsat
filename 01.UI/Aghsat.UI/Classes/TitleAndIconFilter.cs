using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aghsat.UI.Classes.Attributes;

namespace Aghsat.UI.Classes
{
    public class TitleAndIconFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var title = filterContext.ActionDescriptor.GetCustomAttributes(typeof(TitleAttribute), false).FirstOrDefault();
            var icon = filterContext.ActionDescriptor.GetCustomAttributes(typeof(IconeAttribute), false).FirstOrDefault();

            var viewBag = filterContext.Controller.ViewBag;

            viewBag.Title = (title as TitleAttribute)?.Title;
            viewBag.Icon = (icon as IconeAttribute)?.Icon;
        }
    }
}