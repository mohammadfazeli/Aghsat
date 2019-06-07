using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aghsat.UI.Areas.Admin.Controllers
{
    public partial class AdminController : Controller
    {
        public string Messagetype = "";
        public string Message = "";

        public void IslodaFromMain(bool lodaFromMain = false)
        {
            ViewBag.lodaFromMain = lodaFromMain;
        }

        public void SetMessage(string Msg = "", ToastrType type = ToastrType.Info)
        {
            TempData["Messagetype"] = type;
            TempData["Message"] = Msg;
        }
    }
}