using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aghsat.Domain.Entity;
using Aghsat.ViewModel.Product;
using AutoMapper;

namespace Aghsat.UI.Classes.AutoMapperConfig
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {

            
            MapperConfiguration config = new MapperConfiguration(x =>
            {

                #region Product

                x.CreateMap<Product, Product_Add_vm>()
                    .ForMember(d => d.CategoryDropDownList, s => s.Ignore())
                    .ForMember(d => d.UnitDropDownList, s => s.Ignore())

                    .ForAllOtherMembers(d => d.Ignore());


                x.CreateMap<Product_Add_vm, Product>()
                    .ForMember(d => d.Category, s => s.Ignore())
                    .ForMember(d => d.Unit, s => s.Ignore());

                //-   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
                x.CreateMap<Product_List_vm, Product>();
                x.CreateMap<Product, Product_List_vm>()
                    .ForMember(d => d.CategoryName, act => act.MapFrom(s => s.Category.Name))
                    .ForMember(d => d.UnitName, act => act.MapFrom(s => s.Unit.Name))
                    .ForMember(d => d.CategoryName, act => act.MapFrom(s => s.Category.Name));
                //-   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -

                x.CreateMap<Product, Product_Detail_vm>()
                    .ForMember(d => d.CategoryName, act => act.MapFrom(s => s.Category.Name))
                    .ForMember(d => d.UnitName, act => act.MapFrom(s => s.Unit.Name))
                    .ForMember(d => d.CategoryName, act => act.MapFrom(s => s.Category.Name));
                //.ForMember(d => d.ParentCategoryName, act => act.MapFrom(s => s.Category.ParentCategory.Name ==null ? "farhad" :",ah"));

                #endregion

            });
        }

    }
}