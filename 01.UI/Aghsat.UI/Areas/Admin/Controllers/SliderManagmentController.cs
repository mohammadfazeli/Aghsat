using System;
using System.Net;
using System.Web.Mvc;
using System.Web.WebPages;
using Aghsat.DataLayer.AghsatContext;
using Aghsat.Domain.Entity;
using Aghsat.ServiceLayer.Interface;
using Aghsat.UI.Classes.Attributes;
using Aghsat.ViewModel.Slider;
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
    [BreadCrumb(Title = "مدیریت عکس متحرک", UseDefaultRouteUrl = true, RemoveAllDefaultRouteValues = true,
        Order = 0, GlyphIcon = "fa fa-image")]
    [Icone("fa  fa-image")]
    [Title("مدیریت عکس متحرک")]
    [Menu()]
    public partial class SliderManagmentController : AdminController
    {
        #region Field       

        private readonly IUnitOfWork _uow;
        private readonly IPictureService _pictureService;
        private readonly ISliderServices _sliderServices;



        #endregion

        #region Consructor       

        public SliderManagmentController(IUnitOfWork uow, ISliderServices sliderServices, IPictureService pictureService)
        {
            _uow = uow;
            _pictureService = pictureService;
            _sliderServices = sliderServices;
        }

        #endregion

        [Icone("fa  fa-images")]
        [Title("مشاهده عکس های محترک")]
        [Menu()]
        [HttpGet]
        // GET: Admin/Sliders
        public virtual ActionResult Index(bool lodaFromMain = false)
        {
            //IslodaFromMain(lodaFromMain);
            return View();
        }

        [BreadCrumb(Title = "مشاهده عکس های محترک", Order = 1)]
        [Icone("fa fa-images")]
        [Title("مشاهده عکس های محترک")]
        [HttpGet]
        public virtual ActionResult ShowList()
        {

            return PartialView("_ShowListSlider", _sliderServices.GetListVms());
        }

        //[BreadCrumb(Title = "مشاهده عکس های محترک", Order = 2)]
        //// GET: Admin/Sliders/Details/5
        //public virtual ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var Slider = _sliderServices.GetDetailByID(id.GetValueOrDefault());

        //    //Slider Slider = _sliderServices.GetByID(id.GetValueOrDefault());
        //    if (Slider == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(Slider);
        //}

        // GET: Admin/Sliders/Create
        [BreadCrumb(Title = "عکس متحرک جدید", Order = 2)]

        [Icone("fa fa-save")]
        [Title("عکس متحرک جدید")]
        [HttpGet]
        public virtual ActionResult Create(bool lodaFromMain = false)
        {
            //IslodaFromMain(lodaFromMain);
            return View("_CreateSlider", _sliderServices.GetAddVm());
        }
        // GET: Admin/Sliders/Edit/5

        [Icone("fa fa-edit")]
        [Title("ویرایش اطلاعات")]
        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Slider = _sliderServices.GetByID(id.GetValueOrDefault());

            if (Slider == null)
            {
                return HttpNotFound();
            }

            return PartialView("_CreateSlider", _sliderServices.GetAddVm(Slider));


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Icone("fa fa-save")]
        [Title("محصول جدید")]
        public virtual ActionResult Save(Slider_Add_vm ViewModel)
        {

            if (!ModelState.IsValid && !Request.IsAjaxRequest())
            {
                ToastrService.SetMessage(ToastrType.Info, "اشکال در ثبت");
                //return PartialView("_ShowListSliders", _sliderServices.GetAddVm(ViewModel));
                return Json(new { type = AddStatus.Fail, Msg = "" });

            }

            var Sliders = Mapper.Map<Slider_Add_vm, Slider>(ViewModel);

            if (ViewModel.Id == 0)
            {

                #region Insert
                var result = _sliderServices.Create(Sliders);

                switch (result)
                {
                    case AddStatus.Succeeded:

                        _uow.SaveAllChanges();
                        return RedirectToAction(MVC.Admin.SliderManagment.ShowList());

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

                var result = _sliderServices.Update(Sliders);

                switch (result)
                {
                    case updateStatus.Succeeded:

                        _uow.SaveAllChanges();
                        return RedirectToAction(MVC.Admin.SliderManagment.ShowList());


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
                return PartialView("Delete", id);
            }
            return RedirectToAction(MVC.Admin.SliderManagment.Index());
        }

        [Icone("fa fa-image")]
        [Title("افزودن عکس")]
        [HttpGet]
        public virtual ActionResult SetAddPicture(int id)
        {

            return View("_PictureAdd");
        }
        [HttpPost]
        public virtual ActionResult SetAddPicture(Picture_Add_vm ViewModel, HttpPostedFileBase MainImage)
        {

            try
            {
                var modelPicture = Mapper.Map<Picture_Add_vm, Picture>(ViewModel);
                if (ViewModel.Id == 0)
                {

                    #region Insert
                    var result = _pictureService.Create(modelPicture);

                    switch (result)
                    {
                        case AddStatus.Succeeded:

                            _uow.SaveAllChanges();
                            return RedirectToAction(MVC.Admin.SliderManagment.ShowList());


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

                    var result = _pictureService.Update(modelPicture);

                    switch (result)
                    {
                        case updateStatus.Succeeded:

                            _uow.SaveAllChanges();
                            return RedirectToAction(MVC.Admin.SliderManagment.ShowList());


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
            catch (Exception ex)
            {
                return Json(new { type = AddStatus.Error.ToString(), Msg = Message });

            }
        }

        [HttpPost]
        public virtual ActionResult Delete(int id)
        {

            var path = Path.Combine(Server.MapPath("~/Content/Image/SlidersImage"),
                _pictureService.GetByID(id).PictureName);

            var result = _sliderServices.delete(id);
            switch (result)
            {
                case DeleteStatus.Succeeded:
                    try
                    {

                        var resultDelete = _pictureService.delete(id);
                        if (resultDelete == DeleteStatus.Succeeded)
                        {
                            _pictureService.PhysicalDeleteImage(path);
                        }

                    }
                    finally
                    {
                        _uow.SaveAllChanges();

                    }
                    return RedirectToAction(MVC.Admin.SliderManagment.ShowList());


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
