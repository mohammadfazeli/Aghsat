using System.Reflection;
using Aghsat.DataLayer.AghsatContext;
using AutoMapper;
using Aghsat.Domain.Entity;
using Aghsat.ViewModel.Slider;
using Aghsat.ViewModel.Category;
using Aghsat.ViewModel.Product;
using Aghsat.UI.Classes.AutoMapperConfig;

namespace Aghsat.UI.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MapperConfiguration config = new MapperConfiguration(x =>
            {

                x.AddProfile<ProductMapping>();
                x.AddProfile<SliderMapping>();
                x.AddProfile<CategoryMapping>();
                x.AddProfile<ProductMapping>();
                x.AddProfile<PictureMapping>();
                //    #region Commnet



                //#region Slider
                //x.CreateMap<Slider, Slider_List_vm>();
                //x.CreateMap<Slider_List_vm, Slider>();
                ////-   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
                //x.CreateMap<Slider_Add_vm, Slider>();
                //x.CreateMap<Slider, Slider_Add_vm>();
                //#endregion
                //-------------------------------------
                //#region Category

                //x.CreateMap<Category, Category_Add_vm>();

                //x.CreateMap<Category_Add_vm, Category>()
                //    .ForMember(d => d.ParentCategory, s => s.Ignore())
                //    .ForMember(d => d.ParentCategoryId, s => s.Ignore())
                //    .ForMember(d => d.Products, s => s.Ignore())
                //    .ForMember(d => d.SubCategories, s => s.Ignore());

                ////-   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
                //x.CreateMap<Category_List_vm, Category>().ForAllOtherMembers(opts => opts.Ignore());
                //x.CreateMap<Category, Category_List_vm>().ForAllOtherMembers(opts => opts.Ignore());

                //#endregion

                //-------------------------------------
                //#region Product

                //x.CreateMap<Product, Product_Add_vm>()
                //    .ForMember(d => d.CategoryDropDownList, s => s.Ignore())
                //    .ForMember(d => d.UnitDropDownList, s => s.Ignore())

                //    .ForAllOtherMembers(d => d.Ignore());


                //x.CreateMap<Product_Add_vm, Product>()
                //    .ForMember(d => d.Category, s => s.Ignore())
                //    .ForMember(d => d.Unit, s => s.Ignore());

                ////-   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
                //x.CreateMap<Product_List_vm, Product>();
                //x.CreateMap<Product, Product_List_vm>()
                //    .ForMember(d => d.CategoryName, act => act.MapFrom(s => s.Category.Name))
                //    .ForMember(d => d.UnitName, act => act.MapFrom(s => s.Unit.Name))
                //    .ForMember(d => d.CategoryName, act => act.MapFrom(s => s.Category.Name));
                ////-   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -

                //x.CreateMap<Product, Product_Detail_vm>()
                //    .ForMember(d => d.CategoryName, act => act.MapFrom(s => s.Category.Name))
                //    .ForMember(d => d.UnitName, act => act.MapFrom(s => s.Unit.Name))
                //    .ForMember(d => d.CategoryName, act => act.MapFrom(s => s.Category.Name));
                ////.ForMember(d => d.ParentCategoryName, act => act.MapFrom(s => s.Category.ParentCategory.Name ==null ? "farhad" :",ah"));

                //#endregion

                //#endregion

            });

        }
    }
}