using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aghsat.DataLayer.AghsatContext;
using Aghsat.Domain.Entity;
using Aghsat.ServiceLayer;
using Aghsat.ServiceLayer.Interface;
using Aghsat.UI.Classes.Attributes;
using Aghsat.ViewModel.Category;
using AutoMapper;

namespace Aghsat.UI.Areas.Admin.Controllers
{

    [Icone("fa fa-list")]
    [Title("مدیریت دسته بندی ها")]
    [Menu(true)]
    public partial class CategoryManagmentController : Controller
    {


        #region Field       

        private readonly IUnitOfWork _uow;
        private readonly ICategoryServices _categoryServices;

        #endregion

        #region Consructor       

        public CategoryManagmentController(IUnitOfWork uow, ICategoryServices categoryServices)
        {
            _uow = uow;
            _categoryServices = categoryServices;
        }

        #endregion

        #region Action

        [Icone("fa fa-th-list")]
        [Title("مشاهده دسته بندی ها")]
        [Menu(true)]
        [HttpGet]
        public virtual ActionResult Index()
        {

            return View();
        }
        [Icone("fa fa-th-list")]
        [Title("مشاهده دسته بندی ها")]
        [HttpGet]
        public virtual ActionResult ShowList()
        {
            return PartialView("_ShowListCategory", GetListVms());
        }
        [NonAction]
        public IEnumerable<Category_List_vm> GetListVms()
        {
            var categories = _categoryServices.GetAllParentCategories();
            return Mapper.Map<IEnumerable<Category>, IEnumerable<Category_List_vm>>(categories);

        }

        [Icone("fa fa-th-list")]
        [Title("مشاهده  زیر دسته بندی ها")]
        [HttpGet]
        public virtual PartialViewResult GetAllSubCategoriesByParentId(int parentCategoryId)
        {
            return PartialView("_ShowSubCategorys", GetListSubCategories(parentCategoryId));
        }

        [NonAction]
        public IEnumerable<Category_List_vm> GetListSubCategories(int ID)
        {
            var categories = _categoryServices.GetAllSubCategoriesByParentId(ID);
            return Mapper.Map<IEnumerable<Category>, IEnumerable<Category_List_vm>>(categories);
        }


        [HttpGet]
        [Icone("fa fa-save")]
        [Title("دسته بندی جدید")]
        [Menu()]
        public virtual ActionResult Create()
        {
            return PartialView("_CreateCategory", _categoryServices.GetCategory_Add());
        }

        [HttpPost]
        [Icone("fa fa-save")]
        [Title("دسته بندی جدید")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(Category_Add_vm entity)
        {
            if (!ModelState.IsValid && !Request.IsAjaxRequest())
            {
                ToastrService.SetMessage(ToastrType.Info, "اشکال در ثبت");
                return PartialView("_CreateCategory", entity);
            }

            try
            {
                var category = Mapper.Map<Category_Add_vm, Category>(entity);
                var result = _categoryServices.Create(category);

                switch (result)
                {
                    case AddStatus.Succeeded:

                        _uow.SaveAllChanges();
                        ToastrService.AddToUserQueue(new Toastr(message: "ثبت شد", type: ToastrType.Success));
                        //return PartialView("_ShowListCategory", GetListVms());
                        return RedirectToAction(Index());
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
                return PartialView("_ShowListCategory", GetListVms());
            }
            catch (Exception ex)

            {
                ToastrService.SetMessage(ToastrType.Warning, "خطا در ثبت");
                return RedirectToAction("ShowList");
            }

        }

        [HttpGet]
        public virtual ActionResult DeleteCategory(int id)
        {
            try
            {
                var parentCategoryId = _categoryServices.GetByID(id).ParentCategoryId;
                var result = _categoryServices.delete(id);

                switch (result)
                {
                    case DeleteStatus.Succeeded:

                        _uow.SaveAllChanges();
                        ToastrService.AddToUserQueue(new Toastr(message: "ثبت شد", type: ToastrType.Success));
                        break;

                    case DeleteStatus.NotExist:
                        ToastrService.AddToUserQueue(new Toastr(message: "تکراری", type: ToastrType.Info));
                        break;

                    case DeleteStatus.Error:
                        ToastrService.AddToUserQueue(new Toastr(message: "خطا", type: ToastrType.Error));
                        break;

                    case DeleteStatus.Fail:
                        ToastrService.AddToUserQueue(new Toastr(message: "خطا", type: ToastrType.Warning));
                        break;


                }

                if (parentCategoryId == null)
                {
                    return RedirectToAction(Index());
                }
                else
                {
                    return PartialView("_ShowSubCategorys", GetListSubCategories(parentCategoryId.GetValueOrDefault()));
                }

            }
            catch
            {

                ToastrService.AddToUserQueue(new Toastr(message: "خطا", type: ToastrType.Error));
                return PartialView("_ShowListCategory", GetListVms());

            }

        }

        #endregion
    }
}