using Aghsat.ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.Domain.Entity;
using Aghsat.DataLayer.AghsatContext;
using System.Data.Entity;
using Aghsat.ViewModel.Slider;
using AutoMapper;
namespace Aghsat.ServiceLayer.Services
{
    public class PanelManagmentService : IPanelManagmentService
    {

        private readonly IUnitOfWork _uow;
        private readonly IDbSet<Menu> _MenuDbSet;
        private readonly IDbSet<Slider> _SliderDbSet;


        public PanelManagmentService(IUnitOfWork uow)
        {
            _uow = uow;
            _MenuDbSet = _uow.Set<Menu>();
            _SliderDbSet = _uow.Set<Slider>();

        }
        public int Test()
        {
            return 2;
        }
        public IEnumerable<Menu> GetAllMenu()
        {
            return _MenuDbSet
                   .OrderBy(x => x.Id)
                   .ThenBy(x => x.ParentMenuId)
                   .ToList();
        }


        public AddStatus SaveImageSlide(Slider_Add_vm entity)
        {
            var Slider = Mapper.Map<Slider_Add_vm, Slider>(entity);
            Slider.CreateDate = Convert.ToDateTime(PersianCalender.PersianCalender.GetDate());

            try
            {
                _SliderDbSet.Add(Slider);
                _uow.SaveAllChanges();
                return AddStatus.Succeeded;
            }
            catch
            {
                return AddStatus.Error;
            }

        }

        public IEnumerable<Slider_List_vm> GetAllImageSlide()
        {
            var sliders = _SliderDbSet.ToList();
            return Mapper.Map<IEnumerable<Slider>, IEnumerable<Slider_List_vm>>(sliders);

        }
    }
}
