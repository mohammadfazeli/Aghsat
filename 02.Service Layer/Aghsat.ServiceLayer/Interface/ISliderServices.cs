using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.Domain.Entity;
using Aghsat.ViewModel.Slider;

namespace Aghsat.ServiceLayer.Interface
{

    public interface ISliderServices : IEntityService<Slider>
    {

        Slider_Add_vm GetAddVm();
        Slider_Add_vm GetAddVm(Slider_Add_vm ViewModel);
        Slider_Add_vm GetAddVm(Slider model);
        IEnumerable<Slider_List_vm> GetListVms();

    }
}
