using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.DataLayer.AghsatContext;
using Aghsat.Domain.Entity;
using Aghsat.ServiceLayer.Interface;

namespace Aghsat.ServiceLayer.Services
{
    public class PictureService : EntityService<Picture>, IPictureService
    {
        public PictureService(IUnitOfWork uow) : base(uow)
        {
        }

        public override AddStatus Create(Picture entity)
        {
            throw new NotImplementedException();
        }

        //public override DeleteStatus delete(int? id)
        //{
        //    return DeleteStatus.Succeeded;

        //}
        public DeleteStatus PhysicalDeleteImage(string path)
        {            
            try
            {
                var file = new FileInfo(path);
                if (!file.Exists) { return DeleteStatus.NotExist; }

                file.Delete();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return DeleteStatus.Error;
            }

            return DeleteStatus.Succeeded;

        }
        public override IEnumerable<Picture> GetAll()
        {
            throw new NotImplementedException();
        }

        public override updateStatus Update(Picture entity)
        {
            throw new NotImplementedException();
        }
    }
}
