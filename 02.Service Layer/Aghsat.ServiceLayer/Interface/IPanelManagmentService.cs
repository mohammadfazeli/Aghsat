using Aghsat.Domain.Entity;
using Aghsat.ViewModel.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aghsat.ServiceLayer.Interface
{
    public interface IPanelManagmentService
    {
        IEnumerable<Menu> GetAllMenu();
        IEnumerable<Slider_List_vm> GetAllImageSlide();
        AddStatus SaveImageSlide(Slider_Add_vm entity);

    }
}
