using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.DataLayer.AghsatContext;
using Aghsat.Domain.Entity;
using Aghsat.ServiceLayer.Interface;
using Aghsat.ViewModel.Slider;
using AutoMapper;

namespace Aghsat.ServiceLayer.Services
{
    public class SliderServices : EntityService<Slider>, ISliderServices
    {
        private readonly IUnitService _unitService;
        private readonly ICategoryServices _categoryServices;


        public SliderServices(IUnitOfWork uow, IUnitService unitService, ICategoryServices categoryServices) : base(uow)
        {
            _unitService = unitService;
            _categoryServices = categoryServices;
        }

        public override AddStatus Create(Slider entity)
        {
            try
            {
                if (_dbset.Any(x => x.Title == entity.Title && !x.IsDeleted && x.IsActive)) return AddStatus.Exist;
                _dbset.Add(entity);
                return AddStatus.Succeeded;
            }
            catch (Exception ex)
            {
                return AddStatus.Error;
            }


        }

        public override DeleteStatus delete(int? id)
        {
            try
            {
                var Slider = _dbset.Find(id);
                if (Slider == null) return DeleteStatus.NotExist;
                _dbset.Remove(Slider);
                return DeleteStatus.Succeeded;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return DeleteStatus.Error;
            }
        }


        public override updateStatus Update(Slider entity)
        {

            try
            {
                if (_dbset.Any(x => x.Title == entity.Title && !x.IsDeleted && x.IsActive && x.Id != entity.Id)) return updateStatus.Exist;
                _dbset.AddOrUpdate(entity);
                return updateStatus.Succeeded;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return updateStatus.Error;
            }

        }

        #region Get
        public override IEnumerable<Slider> GetAll()
        {
            var Model = _dbset
                .Where(x => x.IsActive && !x.IsDeleted).ToList();

            return Model;
        }


        public Slider_Add_vm GetAddVm()
        {
            return new Slider_Add_vm();
        }
        public Slider_Add_vm GetAddVm(Slider_Add_vm ViewModel)
        {
            return ViewModel;
        }
        public Slider_Add_vm GetAddVm(Slider Slider)
        {
            return new Slider_Add_vm()
            {
                Id = Slider.Id,
                Title = Slider.Title

            };

        }
        public IEnumerable<Slider_List_vm> GetListVms()
        {
            var Sliders = GetAll();

            return Mapper.Map<IEnumerable<Slider>, IEnumerable<Slider_List_vm>>(Sliders);



        }
        #endregion

    }
}
