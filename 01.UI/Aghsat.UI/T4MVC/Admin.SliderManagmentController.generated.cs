// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Aghsat.UI.Areas.Admin.Controllers
{
    public partial class SliderManagmentController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected SliderManagmentController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Edit()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Save()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Save);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ConfirmDelete()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ConfirmDelete);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult SetAddPicture()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SetAddPicture);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Delete()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Delete);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public SliderManagmentController Actions { get { return MVC.Admin.SliderManagment; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Admin";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "SliderManagment";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "SliderManagment";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string ShowList = "ShowList";
            public readonly string Create = "Create";
            public readonly string Edit = "Edit";
            public readonly string Save = "Save";
            public readonly string ConfirmDelete = "ConfirmDelete";
            public readonly string SetAddPicture = "SetAddPicture";
            public readonly string Delete = "Delete";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string ShowList = "ShowList";
            public const string Create = "Create";
            public const string Edit = "Edit";
            public const string Save = "Save";
            public const string ConfirmDelete = "ConfirmDelete";
            public const string SetAddPicture = "SetAddPicture";
            public const string Delete = "Delete";
        }


        static readonly ActionParamsClass_Index s_params_Index = new ActionParamsClass_Index();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Index IndexParams { get { return s_params_Index; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Index
        {
            public readonly string lodaFromMain = "lodaFromMain";
        }
        static readonly ActionParamsClass_Create s_params_Create = new ActionParamsClass_Create();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Create CreateParams { get { return s_params_Create; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Create
        {
            public readonly string lodaFromMain = "lodaFromMain";
        }
        static readonly ActionParamsClass_Edit s_params_Edit = new ActionParamsClass_Edit();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Edit EditParams { get { return s_params_Edit; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Edit
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_Save s_params_Save = new ActionParamsClass_Save();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Save SaveParams { get { return s_params_Save; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Save
        {
            public readonly string ViewModel = "ViewModel";
        }
        static readonly ActionParamsClass_ConfirmDelete s_params_ConfirmDelete = new ActionParamsClass_ConfirmDelete();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ConfirmDelete ConfirmDeleteParams { get { return s_params_ConfirmDelete; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ConfirmDelete
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_SetAddPicture s_params_SetAddPicture = new ActionParamsClass_SetAddPicture();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_SetAddPicture SetAddPictureParams { get { return s_params_SetAddPicture; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_SetAddPicture
        {
            public readonly string id = "id";
            public readonly string ViewModel = "ViewModel";
            public readonly string MainImage = "MainImage";
        }
        static readonly ActionParamsClass_Delete s_params_Delete = new ActionParamsClass_Delete();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Delete DeleteParams { get { return s_params_Delete; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Delete
        {
            public readonly string id = "id";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string _CreateSlider = "_CreateSlider";
                public readonly string _ShowListSlider = "_ShowListSlider";
                public readonly string Create = "Create";
                public readonly string Delete = "Delete";
                public readonly string Details = "Details";
                public readonly string Edit = "Edit";
                public readonly string Index = "Index";
            }
            public readonly string _CreateSlider = "~/Areas/Admin/Views/SliderManagment/_CreateSlider.cshtml";
            public readonly string _ShowListSlider = "~/Areas/Admin/Views/SliderManagment/_ShowListSlider.cshtml";
            public readonly string Create = "~/Areas/Admin/Views/SliderManagment/Create.cshtml";
            public readonly string Delete = "~/Areas/Admin/Views/SliderManagment/Delete.cshtml";
            public readonly string Details = "~/Areas/Admin/Views/SliderManagment/Details.cshtml";
            public readonly string Edit = "~/Areas/Admin/Views/SliderManagment/Edit.cshtml";
            public readonly string Index = "~/Areas/Admin/Views/SliderManagment/Index.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_SliderManagmentController : Aghsat.UI.Areas.Admin.Controllers.SliderManagmentController
    {
        public T4MVC_SliderManagmentController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, bool lodaFromMain);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index(bool lodaFromMain)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "lodaFromMain", lodaFromMain);
            IndexOverride(callInfo, lodaFromMain);
            return callInfo;
        }

        [NonAction]
        partial void ShowListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult ShowList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ShowList);
            ShowListOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, bool lodaFromMain);

        [NonAction]
        public override System.Web.Mvc.ActionResult Create(bool lodaFromMain)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "lodaFromMain", lodaFromMain);
            CreateOverride(callInfo, lodaFromMain);
            return callInfo;
        }

        [NonAction]
        partial void EditOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Edit(int? id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            EditOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void SaveOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Aghsat.ViewModel.Slider.Slider_Add_vm ViewModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult Save(Aghsat.ViewModel.Slider.Slider_Add_vm ViewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Save);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "ViewModel", ViewModel);
            SaveOverride(callInfo, ViewModel);
            return callInfo;
        }

        [NonAction]
        partial void ConfirmDeleteOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult ConfirmDelete(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ConfirmDelete);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ConfirmDeleteOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void SetAddPictureOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult SetAddPicture(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SetAddPicture);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            SetAddPictureOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void SetAddPictureOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Aghsat.ViewModel.Pictures.Picture_Add_vm ViewModel, System.Web.HttpPostedFileBase MainImage);

        [NonAction]
        public override System.Web.Mvc.ActionResult SetAddPicture(Aghsat.ViewModel.Pictures.Picture_Add_vm ViewModel, System.Web.HttpPostedFileBase MainImage)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SetAddPicture);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "ViewModel", ViewModel);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "MainImage", MainImage);
            SetAddPictureOverride(callInfo, ViewModel, MainImage);
            return callInfo;
        }

        [NonAction]
        partial void DeleteOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Delete(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Delete);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DeleteOverride(callInfo, id);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
