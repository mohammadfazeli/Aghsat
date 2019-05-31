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
namespace Aghsat.UI.Areas.Admin.Controllers
{

    [Icone("fa fa-cart-plus")]
    [Title("مدیریت محصولات")]
    [Menu()]
    public partial class ProductsManagmentController : Controller
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
        public virtual ActionResult Index()
        {
            return View();
        }

        [Icone("fa fa-th-list")]
        [Title("مشاهده دسته بندی ها")]
        [HttpGet]
        public virtual ActionResult ShowList()
        {
            return PartialView("_ShowListProduct", _ProductsServices.GetListVms());
        }


        // GET: Admin/Products/Details/5
        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _ProductsServices.GetByID(id.GetValueOrDefault());
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        [Icone("fa fa-save")]
        [Title("محصول جدید")]
        [HttpGet]
        public virtual ActionResult Create()
        {
            return PartialView("_CreateProduct", _ProductsServices.GetAddVm());
        }
        // GET: Admin/Products/Edit/5
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
        public virtual ActionResult Save(Product_Add_vm ViewModel)
        {
            //if (ModelState.IsValid)
            //{
            //    product.ProductDate = Convert.ToDateTime(product.ProductDate);
            //    db.Products.Add(product);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.ProductsId = new SelectList(db.Categories, "Id", "Name", product.ProductsId);
            //ViewBag.UnitId = new SelectList(db.Units, "Id", "Name", product.UnitId);
            //return View(product);

            if (!ModelState.IsValid && !Request.IsAjaxRequest())
            {
                ToastrService.SetMessage(ToastrType.Info, "اشکال در ثبت");
                return PartialView("_ShowListProducts", _ProductsServices.GetAddVm(ViewModel));

            }

            //try
            //{
            var Products = Mapper.Map<Product_Add_vm, Product>(ViewModel);
            Products.CreateDate = Convert.ToDateTime(Products.CreateDate).ToShortDateString().AsDateTime();
            var result = _ProductsServices.Create(Products);

            switch (result)
            {
                case AddStatus.Succeeded:

                    _uow.SaveAllChanges();
                    ToastrService.AddToUserQueue(new Toastr(message: "ثبت شد", type: ToastrType.Success));
                    //return PartialView("_ShowListProduct", _ProductsServices.GetListVms());
                    //return PartialView("_CreateProduct", _ProductsServices.GetAddVm());
                    //return PartialView("_CreateProduct", _ProductsServices.GetAddVm());
                    return RedirectToAction(MVC.Admin.ProductsManagment.ShowList());


                case AddStatus.Exist:
                    ToastrService.AddToUserQueue(new Toastr(message: "تکراری", type: ToastrType.Info));
                    break;

                case AddStatus.Error:
                    ToastrService.AddToUserQueue(new Toastr(message: "خطا", type: ToastrType.Error));
                    break;

                case AddStatus.Fail:
                    ToastrService.AddToUserQueue(new Toastr(message: "خطا", type: ToastrType.Warning));
                    break;


            }
            return PartialView("_ShowListProducts", _ProductsServices.GetAddVm(ViewModel));
            //}
            //catch (Exception ex)

            //{
            //    ToastrService.SetMessage(ToastrType.Warning, "خطا در ثبت");

            //    return PartialView("_ShowListProducts", _ProductsServices.GetAddVm(ViewModel));

            //}

        }



        //// POST: Admin/Products/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public virtual ActionResult Edit([Bind(Include = "Id,Name,ProductDate,MainImage,UnitId,ProductsId,CreateDate,ModifeDate,IsDeleted,IsActive")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(product).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ProductsId = new SelectList(db.Categories, "Id", "Name", product.ProductsId);
        //    ViewBag.UnitId = new SelectList(db.Units, "Id", "Name", product.UnitId);
        //    return View(product);
        //}

        //// GET: Admin/Products/Delete/5
        //public virtual ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = _ProductsServices.GetByID(id.GetValueOrDefault());
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}

        // POST: Admin/Products/Delete/5
        [HttpGet]
        public virtual ActionResult Delete(int id)
        {
            var result = _ProductsServices.delete(id);
            switch (result)
            {
                case DeleteStatus.Succeeded:

                    _uow.SaveAllChanges();
                    ToastrService.AddToUserQueue(new Toastr(message: "ثبت شد", type: ToastrType.Success));
                    return RedirectToAction(MVC.Admin.ProductsManagment.ShowList());

                case DeleteStatus.NotExist:
                    ToastrService.AddToUserQueue(new Toastr(message: "وجود ندارد", type: ToastrType.Info));
                    break;

                case DeleteStatus.Error:
                    ToastrService.AddToUserQueue(new Toastr(message: "خطا", type: ToastrType.Error));
                    break;

                case DeleteStatus.Fail:
                    ToastrService.AddToUserQueue(new Toastr(message: "خطا", type: ToastrType.Warning));
                    break;


            }
            return PartialView("_ShowListProducts", _ProductsServices.GetAddVm());
        }


    }
}
