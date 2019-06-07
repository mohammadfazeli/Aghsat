using System;
using System.Net;
using System.Web.Mvc;
using System.Web.WebPages;
using Aghsat.DataLayer.AghsatContext;
using Aghsat.Domain.Entity;
using Aghsat.ServiceLayer.Interface;
using Aghsat.UI.Classes.Attributes;
using Aghsat.ViewModel.Product;
using AutoMapper;
using Aghsat.ServiceLayer;
using System.Web;
using System.IO;
using System.Linq;
using DNTBreadCrumb;
using Microsoft.Owin.Security.Provider;

namespace Aghsat.UI.Areas.Admin.Controllers
{
    [BreadCrumb(Title = "مدیریت محصولات", UseDefaultRouteUrl = true, RemoveAllDefaultRouteValues = true,
        Order = 0, GlyphIcon = "fa fa-cart-plus")]
    [Icone("fa fa-cart-plus")]
    [Title("مدیریت محصولات")]
    [Menu()]
    public partial class ProductsManagmentController : AdminController
    {
        #region Field       

        private readonly IUnitOfWork _uow;
        private readonly IProductServices _ProductsServices;

        #endregion

        #region Consructor       

        public ProductsManagmentController(IUnitOfWork uow, IProductServices ProductsServices)
        {
            _uow = uow;
            _ProductsServices = ProductsServices;
        }

        #endregion

        [Icone("fa fa-th-list")]
        [Title("مشاهده محصولات ها")]
        [Menu()]
        [HttpGet]
        // GET: Admin/Products
        public virtual ActionResult Index(bool lodaFromMain = false)
        {
            //IslodaFromMain(lodaFromMain);
            return View();
        }

        [BreadCrumb(Title = "مشاهده محصولات ها", Order = 1)]
        [Icone("fa fa-th-list")]
        [Title("مشاهده دسته بندی ها")]
        [HttpGet]
        public virtual ActionResult ShowList()
        {
            ToastrService.AddToUserQueue(new Toastr(message: "ثبت شد", type: ToastrType.Success));

            return PartialView("_ShowListProduct", _ProductsServices.GetListVms());
        }

        [BreadCrumb(Title = "مشاهده محصولات ها", Order = 2)]
        // GET: Admin/Products/Details/5
        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = _ProductsServices.GetDetailByID(id.GetValueOrDefault());

            //Product product = _ProductsServices.GetByID(id.GetValueOrDefault());
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        [BreadCrumb(Title = "محصول جدید", Order = 2)]

        [Icone("fa fa-save")]
        [Title("محصول جدید")]
        [HttpGet]
        public virtual ActionResult Create(bool lodaFromMain = false)
        {
            //IslodaFromMain(lodaFromMain);
            return View("_CreateProduct", _ProductsServices.GetAddVm());
        }
        // GET: Admin/Products/Edit/5

        [Icone("fa fa-edit")]
        [Title("ویرایش اطلاعات")]
        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _ProductsServices.GetByID(id.GetValueOrDefault());

            if (product == null)
            {
                return HttpNotFound();
            }

            return PartialView("_CreateProduct", _ProductsServices.GetAddVm(product));


        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Icone("fa fa-save")]
        [Title("محصول جدید")]
        public virtual ActionResult Save(Product_Add_vm ViewModel, HttpPostedFileBase MainImage)
        {

            if (!ModelState.IsValid && !Request.IsAjaxRequest() || MainImage == null)
            {
                ToastrService.SetMessage(ToastrType.Info, "اشکال در ثبت");
                return PartialView("_ShowListProducts", _ProductsServices.GetAddVm(ViewModel));

            }

            //try
            //{
            var fileName = Path.GetFileName(MainImage.FileName);
            ViewModel.MainImage = fileName;

            var Products = Mapper.Map<Product_Add_vm, Product>(ViewModel);
            var path = Path.Combine(Server.MapPath("~/Content/Image/ProductsImage"), fileName);

            var result = _ProductsServices.Create(Products);

            switch (result)
            {
                case AddStatus.Succeeded:

                    _uow.SaveAllChanges();
                    MainImage.SaveAs(path);
                    return RedirectToAction(MVC.Admin.ProductsManagment.ShowList());

                case AddStatus.Exist:

                    Messagetype = AddStatus.Exist.ToString();
                    Message = "";
                    break;
                case AddStatus.Error:

                    Messagetype = AddStatus.Error.ToString();
                    Message = "";
                    break;
                case AddStatus.Fail:

                    Messagetype = AddStatus.Fail.ToString();
                    Message = "";
                    break;

            }
            return Json(new { type = Messagetype, Msg = Message });


        }

        [Icone("fa fa-trash")]
        [Title("حذف")]
        [HttpGet]
        public virtual ActionResult ConfirmDelete(int id)
        {

            if (id > 0)
            {
                return PartialView("Delete", id);
            }

            return RedirectToAction(MVC.Admin.ProductsManagment.Index());
        }

        [HttpPost]
        public virtual ActionResult Delete(int id)
        {

            var fileName = _ProductsServices.GetByID(id).MainImage;
            var path = Path.Combine(Server.MapPath("~/Content/Image/ProductsImage"), fileName);

            var result = _ProductsServices.delete(id);
            switch (result)
            {
                case DeleteStatus.Succeeded:
                    try
                    {
                        var file = new FileInfo(path);
                        if (file.Exists)
                        {

                            file.Delete();
                        }
                    }
                    finally
                    {
                        _uow.SaveAllChanges();

                    }
                    return RedirectToAction(MVC.Admin.ProductsManagment.ShowList());

                case DeleteStatus.NotExist:

                    Messagetype = DeleteStatus.NotExist.ToString();
                    Message = "";
                    break;
                case DeleteStatus.Error:

                    Messagetype = DeleteStatus.Error.ToString();
                    Message = "";
                    break;
                case DeleteStatus.Fail:

                    Messagetype = DeleteStatus.Fail.ToString();
                    Message = "";
                    break;

            }
            return Json(new { type = Messagetype, Msg = Message });

        }


    }
}
