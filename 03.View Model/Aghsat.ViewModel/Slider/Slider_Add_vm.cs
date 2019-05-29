using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aghsat.ViewModel.Slider
{
    public class Slider_Add_vm : BaseViewModel
    {
        [Display(Name = "ImageName", ResourceType = typeof(Resources.Resource))]
        public string ImageName { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resources.Resource))]
        public string Title { get; set; }

        [Display(Name = "ShortDescription", ResourceType = typeof(Resources.Resource))]
        public string ShortDescription { get; set; }

        public int order { get; set; }

    }
}
