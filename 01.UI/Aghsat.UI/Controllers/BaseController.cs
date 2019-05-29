using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aghsat.UI.Controllers
{
    public partial class BaseController : Controller
    {


        public virtual ActionResult Message()
        {
            ViewBag.message = "سلام فرهاد";
            return PartialView("_Message");
        }

    }
}