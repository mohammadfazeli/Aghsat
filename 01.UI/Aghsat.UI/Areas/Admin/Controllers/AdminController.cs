using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aghsat.UI.Areas.Admin.Controllers
{
    public partial class AdminController : Controller
    {
        public void IslodaFromMain(bool lodaFromMain = false)
        {
            ViewBag.lodaFromMain = lodaFromMain;
        }
    }
}