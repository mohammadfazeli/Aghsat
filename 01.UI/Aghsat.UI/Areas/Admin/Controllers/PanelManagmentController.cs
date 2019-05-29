using Aghsat.DataLayer.AghsatContext;
using Aghsat.ServiceLayer.Interface;
using Aghsat.ViewModel.Slider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aghsat.ServiceLayer;
using System.Reflection;
using Aghsat.UI.Areas.Admin.Models;
using Aghsat.UI.Classes.Attributes;
namespace Aghsat.UI.Areas.Admin.Controllers
{
    [Menu]
    [Title("پنل مدیریت")]
    [Icone("fa fa-building")]
    public partial class PanelManagmentController : Controller
    {

        private readonly IUnitOfWork _uow;
        private readonly IPanelManagmentService _PanelManagmentService;

        public PanelManagmentController(IUnitOfWork uow, IPanelManagmentService PanelManagmentService)
        {
            _uow = uow;
            _PanelManagmentService = PanelManagmentService;
        }


        // GET: Admin/PanelManagment
        [Menu]
        [Title("دیدت صفحات")]
        [Icone("fa fa-adjust")]
        [HttpGet]
        public virtual ActionResult Index()
        {


            Assembly asm = Assembly.GetExecutingAssembly();

            var controlleractionlist = asm.GetTypes()
                    .Where(type => typeof(System.Web.Mvc.Controller).IsAssignableFrom(type))
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .Select(x => new
                    {
                        Controller = x.DeclaringType.Name.Replace("Controller", ""),// x.DeclaringType.Name,
                        ControllerName = (x.DeclaringType.GetCustomAttributes(typeof(TitleAttribute), false).FirstOrDefault() as TitleAttribute), //, x.DeclaringType.Name,
                        ControllerIcon = (x.DeclaringType.GetCustomAttributes(typeof(IconeAttribute), false).FirstOrDefault() as IconeAttribute), //, x.DeclaringType.Name,
                        Action = x.Name,
                        ActionName = (x.GetCustomAttributes(typeof(TitleAttribute), false).FirstOrDefault() as TitleAttribute), //x.Name,
                        Icon = (x.GetCustomAttributes(typeof(IconeAttribute), false).FirstOrDefault() as IconeAttribute),
                        ReturnType = x.ReturnType.Name,
                        Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", "")))

                    })
                    .OrderBy(x => x.Controller)/*.ThenBy(x => x.Action).*/.Where(x => x.Attributes.Contains("Menu") && x.Attributes.Contains("HttpGet") && !x.Controller.Contains("T4MVC")).ToList();

            var list = new List<ControllerActions>();
            var ControllerList = new List<ListControllers>();

            var Controllers = controlleractionlist.Select(t => t.ControllerName.Title).Distinct().ToList();


            foreach (var item in controlleractionlist)
            {

                list.Add(new ControllerActions()
                {
                    Controller = item.Controller,
                    ControllerName = item.ControllerName.Title,
                    ControllerIcon = item.ControllerIcon.Icon,
                    ActionName = item.ActionName.Title,
                    Action = item.Action,
                    ActionIcon = item.Icon.Icon,
                    Attributes = item.Attributes,
                    ReturnType = item.ReturnType
                });

            }



            //ViewBag.list = list;

            return View(list);
        }

        [Menu(false)]
        public virtual PartialViewResult Menu()
        {

            //////Assembly asm = Assembly.GetExecutingAssembly();

            //////var controlleractionlist = asm.GetTypes()
            //////        .Where(type => typeof(System.Web.Mvc.Controller).IsAssignableFrom(type))
            //////        .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
            //////        .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
            //////        .Select(x => new
            //////        {
            //////            Controller = x.DeclaringType.Name,
            //////            Action = (x.GetCustomAttributes(typeof(TitleAttribute), false).FirstOrDefault() as TitleAttribute), //x.Name,
            //////            Icon = (x.GetCustomAttributes(typeof(IconeAttribute), false).FirstOrDefault() as IconeAttribute),
            //////            ReturnType = x.ReturnType.Name,
            //////            Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", "")))
            //////        })
            //////        .OrderBy(x => x.Controller)/*.ThenBy(x => x.Action).*/.Where(x => x.Attributes.Contains("Menu") /* && x.Attributes.Contains("HttpGet") */&& !x.Controller.Contains("T4MVC")).ToList();
            //////var list = new List<ControllerActions>();
            //////foreach (var item in controlleractionlist)
            //////{
            //////    list.Add(new ControllerActions()
            //////    {
            //////        Controller = item.Controller,
            //////        Action = item.Action.Title,
            //////        Icon = item.Icon.Icon,
            //////        Attributes = item.Attributes,
            //////        ReturnType = item.ReturnType
            //////    });
            //////}



            var asm = Assembly.GetExecutingAssembly();

            var controlleractionlist = asm.GetTypes()
                    .Where(type => typeof(System.Web.Mvc.Controller).IsAssignableFrom(type))
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .Select(x => new
                    {
                        Controller = x.DeclaringType.Name.Replace("Controller", ""),// x.DeclaringType.Name,
                        ControllerName = (x.DeclaringType.GetCustomAttributes(typeof(TitleAttribute), false).FirstOrDefault() as TitleAttribute), //, x.DeclaringType.Name,
                        ControllerIcon = (x.DeclaringType.GetCustomAttributes(typeof(IconeAttribute), false).FirstOrDefault() as IconeAttribute), //, x.DeclaringType.Name,
                        Action = x.Name,
                        ActionName = (x.GetCustomAttributes(typeof(TitleAttribute), false).FirstOrDefault() as TitleAttribute), //x.Name,
                        Icon = (x.GetCustomAttributes(typeof(IconeAttribute), false).FirstOrDefault() as IconeAttribute),
                        ReturnType = x.ReturnType.Name,
                        Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", "")))

                    })
                    .OrderBy(x => x.Controller)/*.ThenBy(x => x.Action).*/.Where(x => x.Attributes.Contains("Menu") && x.Attributes.Contains("HttpGet") && !x.Controller.Contains("T4MVC")).ToList();

            var list = new List<ControllerActions>();
            var controllerList = new List<ListControllers>();

            var controllers = controlleractionlist.Select(t => t.ControllerName.Title).Distinct().ToList();


            foreach (var item in controlleractionlist)
            {

                list.Add(new ControllerActions()
                {
                    Controller = item.Controller,
                    ControllerName = item.ControllerName.Title,
                    ControllerIcon = item.ControllerIcon.Icon,
                    ActionName = item.ActionName.Title,
                    Action = item.Action,
                    ActionIcon = item.Icon.Icon,
                    Attributes = item.Attributes,
                    ReturnType = item.ReturnType
                });

            }
            return PartialView("_AdminMenu", list);

            //return PartialView("_AdminMenu", _PanelManagmentService.GetAllMenu());



        }

        [HttpGet]
        [Menu]
        [Title(" متحرک")]
        [Icone("fa fa-image")]
        public virtual ActionResult SaveUserSlide()
        {
            return View();


        }

        [HttpGet]
        [Menu]
        [Title("مدیریت عکس های متحرک")]
        [Icone("fa fa-user")]
        public virtual ActionResult ManagmentSliderImages()
        {
            //if (TempData["Message"] == null) return View();
            //TempData["Message"] = "yes";

            //ToastrService.AddToUserQueue(new Toastr(message: TempData["Message"].ToString(), type: ToastrType.Success));
            return View();
        }

        [HttpGet]
        public virtual PartialViewResult ShowImages()
        {
            var sliders = _PanelManagmentService.GetAllImageSlide();
            return PartialView("_ShowImages", sliders);

        }

        [HttpGet]
        [Title("عکس متحرک")]
        [Icone("fa fa-user")]
        public virtual PartialViewResult SaveImageSlide()
        {
            return PartialView("_SaveImageSlide");

        }

        [HttpPost]
        [Menu(false)]
        public virtual ActionResult SaveImageSlide(Slider_Add_vm img, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength <= 0) return PartialView("_SaveImageSlide");
            try
            {
                var fileName = Path.GetFileName(file.FileName);
                img.ImageName = fileName;

                var path = Path.Combine(Server.MapPath("~/Content/Image"), fileName);
                if (_PanelManagmentService.SaveImageSlide(img) == AddStatus.Succeeded)
                {
                    file.SaveAs(path);

                    ToastrService.AddToUserQueue(new Toastr(message: "عکس اضافه گردید", type: ToastrType.Success));
                    return RedirectToAction("ManagmentSliderImages");


                }
                else
                    return RedirectToAction("ManagmentSliderImages");

            }
            catch (Exception ex)
            {
                TempData["errorMesage"] = ex.Message.ToString();
                // <script></script> no needed..
                return RedirectToAction("ShowImages");

            }
        }


    }
}