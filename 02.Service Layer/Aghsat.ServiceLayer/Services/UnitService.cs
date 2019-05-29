using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.DataLayer.AghsatContext;
using Aghsat.Domain.Entity;
using Aghsat.ServiceLayer.Interface;

namespace Aghsat.ServiceLayer.Services
{
    public  class UnitService :EntityService<Unit>,IUnitService
    {
        public UnitService(IUnitOfWork uow) : base(uow)
        {
        }

        public override AddStatus Create(Unit entity)
        {
            throw new NotImplementedException();
        }

        public override DeleteStatus delete(int? id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Unit> GetAll()
        {
            return _dbset.Where(x => x.IsActive && !x.IsDeleted).ToList();
        }

        public override updateStatus Update(Unit entity)
        {
            throw new NotImplementedException();
        }
    }
}
