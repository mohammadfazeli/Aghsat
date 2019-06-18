using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.ViewModel.Pictures;

namespace Aghsat.ViewModel.Slider
{
    public class Slider_Add_vm : BaseViewModel
    {

        [Display(Name = "Title", ResourceType = typeof(Resources.Resource))]
        public string Title { get; set; }
        //---------------------------------------------------------

        [Display(Name = "PictureName", ResourceType = typeof(Resources.Resource))]
        [Required(ErrorMessageResourceName = nameof(Resources.Resource.ISRequired),
            ErrorMessageResourceType = typeof(Resources.Resource))]
        [StringLength(30, ErrorMessageResourceName = nameof(Resources.Resource.MaxLength30),
            ErrorMessageResourceType = typeof(Resources.Resource))]
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
