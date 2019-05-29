using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.Domain.Entity;
using Aghsat.ViewModel.Product;

namespace Aghsat.ServiceLayer.Interface
{

    public interface IProductServices : IEntityService<Product>
    {

        Product_Add_vm GetAddVm();
        Product_Add_vm GetAddVm(Product_Add_vm ViewModel);
        Product_Add_vm GetAddVm(Product model);
        IEnumerable<Product_List_vm> GetListVms();
    }
}
