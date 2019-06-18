using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aghsat.Domain.Entity;
using Aghsat.ViewModel.Category;
using AutoMapper;

namespace Aghsat.UI.Classes.AutoMapperConfig
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            MapperConfiguration config = new MapperConfiguration(x =>
            {
                #region Category

                x.CreateMap<Category, Category_Add_vm>();

                x.CreateMap<Category_Add_vm, Category>()
                    .ForMember(d => d.ParentCategory, s => s.Ignore())
                    .ForMember(d => d.ParentCategoryId, s => s.Ignore())
                    .ForMember(d => d.Products, s => s.Ignore())
                    .ForMember(d => d.SubCategories, s => s.Ignore());

                //-   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
                x.CreateMap<Category_List_vm, Category>().ForAllOtherMembers(opts => opts.Ignore());
                x.CreateMap<Category, Category_List_vm>().ForAllOtherMembers(opts => opts.Ignore());

                #endregion
            });
        }
    }
}