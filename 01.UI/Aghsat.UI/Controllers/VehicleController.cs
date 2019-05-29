using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aghsat.Domain.Entity;
using Aghsat.DataLayer.AghsatContext;
using Aghsat.ServiceLayer.Interface;
using AutoMapper;
using Aghsat.ViewModel.Vehicle_vm;
using GemBox;
using GemBox.Spreadsheet;
namespace Aghsat.UI.Controllers
{
    public partial class VehicleController : BaseController
    {

        private readonly IUnitOfWork _uow;
        private readonly IVehicleService _VehicleService;

        public VehicleController(IUnitOfWork uow, IVehicleService VehicleService)
        {
            _uow = uow;
            _VehicleService = VehicleService;
        }
        // GET: Vehicle
        public virtual ActionResult Index()
        {
            //var Vehicles = _VehicleService.GetByID(1);
            var Vehicles = _VehicleService.GetAll();

            var x = Mapper.Map<IEnumerable<Vehicle>, IEnumerable<Vehicle_List_vm>>(Vehicles);
            return View(x);

        }
    }
}