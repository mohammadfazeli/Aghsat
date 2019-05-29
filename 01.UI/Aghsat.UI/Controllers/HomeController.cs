using Aghsat.UI.CustomFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersianCalender;
using Aghsat.ServiceLayer.Interface;
using Aghsat.DataLayer.AghsatContext;
using Aghsat.UI.Classes.Attributes;
using DNTBreadCrumb;

namespace Aghsat.UI.Controllers
{
    [BreadCrumb(Title = "Home", UseDefaultRouteUrl = true, Order = 0)]
    public partial class HomeController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IPanelManagmentService _panelManagmentService;

        public HomeController(IUnitOfWork uow, IPanelManagmentService PanelManagmentService)
        {
            _uow = uow;
            _panelManagmentService = PanelManagmentService;

        }

        [Title("خانه")]
        [Icone("fa fa-home")]
        [BreadCrumb(Title = "Main index", GlyphIcon = "fa fa-home", Order = 1)]
        public virtual ActionResult Index()
        {

            ToastrService.AddToUserQueue(new Toastr(message: "Customer added.", type: ToastrType.Success));
            return View();
        }
        [Title("درباره ما")]
        [Icone("fa fa-group")]
        [BreadCrumb(Title = "درباره ما", GlyphIcon = "fa fa-group",Order =2)]

        public virtual ActionResult About()
        {

            //PersianCalender.PersianCalender p = new PersianCalender.PersianCalender();
            //ViewBag.Data = p.GetDate();
            //ViewBag.Data = p.GetDateByDay();
            ViewBag.Data = PersianCalender.PersianCalender.GetDayOfWeek();

            ToastrService.AddToUserQueue(new Toastr(message: "Customer added.", type: ToastrType.Warning));

            return View();

        }

       // [Authorize(Roles = "Admin")]
        [Title("ارتباط با ما")]
        [Icone("glyphicon glyphicon-volume-up")]
        [BreadCrumb(Title = "ارتباط با ما", GlyphIcon = "lyphicon glyphicon-volume-up", Order = 3)]

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public virtual PartialViewResult Slideshow()
        {
            return PartialView("_Slideshow", _panelManagmentService.GetAllImageSlide());
        }
    }
}