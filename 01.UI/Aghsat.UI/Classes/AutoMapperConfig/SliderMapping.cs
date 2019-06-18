using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aghsat.Domain.Entity;
using Aghsat.ViewModel.Slider;
using AutoMapper;

namespace Aghsat.UI.Classes.AutoMapperConfig
{
    public class SliderMapping : Profile
    {
        public SliderMapping()
        {
            MapperConfiguration config = new MapperConfiguration(x =>
            {

                #region Slider

                #region list

                x.CreateMap<Slider, Slider_List_vm>();
                x.CreateMap<Slider_List_vm,Slider>();



                //x.CreateMap<Slider_List_vm, Slider>()
                //    .ForMember(d => d.Picture.PictureName, s => s.MapFrom(o => o.PictureName))
                //    .ForMember(d => d.Picture.DisplayPriority, s => s.MapFrom(o => o.DisplayPriority))
                //    .ForMember(d => d.Picture.ShortDescription, s => s.MapFrom(o => o.ShortDescription));



                #endregion

                //-   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -

                #region Add              

                x.CreateMap<Slider_Add_vm, Slider>();
                x.CreateMap<Slider, Slider_Add_vm>();

                #endregion

                #endregion
            });
        }
    }
}