using Aghsat.Domain.Entity;
using Aghsat.UI.Classes.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aghsat.UI.Areas.Admin.Controllers
{

    [Menu]
    [Title("پنل خودرو")]
    [Icone("fa fa-list-alt")]
    public partial class VehicleManagmentController : Controller
    {
        // GET: Admin/VehicleManagment
        [HttpGet]
        [Menu]
        [Title("نمایش خودرو")]
        [Icone("fa fa-apple")]
        public virtual ActionResult Index()
        {
            return View();
        }
       
    }
}