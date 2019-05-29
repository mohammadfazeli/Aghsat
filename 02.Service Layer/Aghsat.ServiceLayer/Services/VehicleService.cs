using Aghsat.DataLayer.AghsatContext;
using Aghsat.Domain.Entity;
using Aghsat.ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aghsat.ServiceLayer.Services
{
    public class VehicleService : EntityService<Vehicle>, IVehicleService
    {
        public VehicleService(IUnitOfWork uow) : base(uow) { }

        public override AddStatus Create(Vehicle entity)
        {
            return AddStatus.Succeeded;
        }

        public override DeleteStatus delete(int? id)
        {
            return DeleteStatus.Succeeded;
        }

        public override IEnumerable<Vehicle> GetAll()
        {
            return _dbset.ToList();
        }

        public override updateStatus Update(Vehicle entity)
        {
            return updateStatus.Succeeded;
        }
    }
}
