using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aghsat.ViewModel.Pictures
{
    public class Picture_List_vm : BaseViewModel
    {

        [Display(Name = "PictureName", ResourceType = typeof(Resources.Resource))]
        public string PictureName { get; set; }
        //---------------------------------------------------------
        [Display(Name = "ShortDescription", ResourceType = typeof(Resources.Resource))]
        public string ShortDescription { get; set; }
        //---------------------------------------------------------

        [Display(Name = "DisplayPriority", ResourceType = typeof(Resources.Resource))]
        public int? DisplayPriority { get; set; }
        //---------------------------------------------------------

        public int ProductDetailId { get; set; }
        //---------------------------------------------------------
        public int SliderId { get; set; }
    }
}
