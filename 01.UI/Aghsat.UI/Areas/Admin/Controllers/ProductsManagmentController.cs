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
using Aghsat.ViewModel.Pictures;
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
        private readonly IPictureService _pictureService;


        #endregion

        #region Consructor       

        public ProductsManagmentController(IUnitOfWork uow, IProductServices ProductsServices, IPictureService pictureService)
        {
            _uow = uow;
            _ProductsServices = ProductsServices;
            _pictureService = pictureService;

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
                //return PartialView("_ShowListProducts", _ProductsServices.GetAddVm(ViewModel));
                return Json(new { type = "Fail", Msg = "کاربر گرامی عکسی انتخاب نشده است" });

            }

            var fileName = Path.GetFileName(MainImage.FileName);
            ViewModel.MainImage = fileName;
            var ServerMapPath = Server.MapPath("~/Content/Image/ProductsImage");

            var Products = Mapper.Map<Product_Add_vm, Product>(ViewModel);
            var path = Path.Combine(ServerMapPath, fileName);

            if (ViewModel.Id == 0)
            {

                #region Insert
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


                #endregion
            }
            else
            {
                #region updata
                var OldMainImage = _ProductsServices.GetByID(Products.Id).MainImage;
                var Oldpath = Path.Combine(ServerMapPath, OldMainImage);

                var result = _ProductsServices.Update(Products);

                switch (result)
                {
                    case updateStatus.Succeeded:

                        _uow.SaveAllChanges();
                        DeleteImage(Oldpath);
                        MainImage.SaveAs(path);
                        return RedirectToAction(MVC.Admin.ProductsManagment.ShowList());

                    case updateStatus.Exist:

                        Messagetype = updateStatus.Exist.ToString();
                        Message = "";
                        break;
                    case updateStatus.Error:

                        Messagetype = updateStatus.Error.ToString();
                        Message = "";
                        break;
                    case updateStatus.Fail:

                        Messagetype = updateStatus.Fail.ToString();
                        Message = "";
                        break;

                }

                #endregion
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
                return PartialView("_DeleteModal", id);
            }

            return RedirectToAction(MVC.Admin.ProductsManagment.Index());
        }

        [Icone("fa fa-image")]
        [Title("افزودن عکس")]
        [HttpGet]
        public virtual ActionResult SetAddPicture(int id)
        {
            var x = new Picture_Add_vm()
            {
                ProductDetailId = id
            };
            return View("_PictureAdd", x);
        }
        [HttpPost]
        public virtual ActionResult SetAddPicture(Picture_Add_vm model, HttpPostedFileBase MainImage)
        {

            try
            {
                var modelPicture = Mapper.Map<Picture_Add_vm, Picture>(model);

            }
            catch (Exception ex)
            {
                return Json(new { type = AddStatus.Error.ToString(), Msg = Message });

            }
            return Json(new { type = AddStatus.Succeeded.ToString(), Msg = Message });
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
                        DeleteImage(path);
                        //var resultDelete = _pictureService.delete(id);
                        //if (resultDelete == DeleteStatus.Succeeded)
                        //{
                        //    _pictureService.PhysicalDeleteImage(path);
                        //}

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

        private void DeleteImage(string path)
        {
            var file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
        }
    }
}
