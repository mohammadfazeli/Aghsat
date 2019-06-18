using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.Domain.Entity;

namespace Aghsat.ServiceLayer.Interface
{
    public interface IPictureService : IEntityService<Picture>
    {
        DeleteStatus PhysicalDeleteImage(string path);
    }
}
