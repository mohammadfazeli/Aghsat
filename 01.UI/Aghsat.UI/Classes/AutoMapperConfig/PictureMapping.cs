using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aghsat.Domain.Entity;
using Aghsat.ViewModel.Pictures;
using Aghsat.ViewModel.Slider;
using AutoMapper;

namespace Aghsat.UI.Classes.AutoMapperConfig
{
    public class PictureMapping : Profile
    {
        public PictureMapping()
        {

            MapperConfiguration config = new MapperConfiguration(x =>
            {

                #region Slider

                x.CreateMap<Picture_Add_vm, Picture>();



                //-   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
                //x.CreateMap<Slider_Add_vm, Slider>();
                //x.CreateMap<Slider, Slider_Add_vm>();

                #endregion
            });
        }
    }
}