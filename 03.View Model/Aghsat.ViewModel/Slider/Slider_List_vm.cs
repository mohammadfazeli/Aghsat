using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.Domain.Entity;
using Aghsat.ViewModel.Pictures;

namespace Aghsat.ViewModel.Slider
{
    public class Slider_List_vm : BaseViewModel
    {

        [Display(Name = nameof(Resources.Resource.Title), ResourceType = typeof(Resources.Resource))]
        public string Title { get; set; }

        [Display(Name = "PictureName", ResourceType = typeof(Resources.Resource))]
      
        public string PictureName { get; set; }
        //---------------------------------------------------------
        [Display(Name = "ShortDescription", ResourceType = typeof(Resources.Resource))]
        public string ShortDescription { get; set; }
        //---------------------------------------------------------
        [Display(Name = "DisplayPriority", ResourceType = typeof(Resources.Resource))]
        public int? DisplayPriority { get; set; }
        //---------------------------------------------------------        

    }
}
