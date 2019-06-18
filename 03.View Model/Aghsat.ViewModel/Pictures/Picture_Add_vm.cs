using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Aghsat.ViewModel.Pictures
{
    public class Picture_Add_vm : BaseViewModel
    {

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
           ErrorMessageResourceName = nameof(Resources.Resource.ISRequired))]

        [Display(Name = nameof(Resources.Resource.Pictures), ResourceType = typeof(Resources.Resource))]
        public string PictureName { get; set; }
        //---------------------------------------------------------
        [StringLength(20, ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = nameof(Resources.Resource.ShortDescription))]

        [Display(Name = nameof(Resources.Resource.ShortDescription), ResourceType = typeof(Resources.Resource))]
        public string ShortDescription { get; set; }
        //---------------------------------------------------------
        [Display(Name = nameof(Resources.Resource.DisplayPriority), ResourceType = typeof(Resources.Resource))]
        public int? DisplayPriority { get; set; }
        //---------------------------------------------------------
        [Display(Name = nameof(Resources.Resource.ProductDetailId), ResourceType = typeof(Resources.Resource))]

        public int? ProductDetailId { get; set; }
        public Domain.Entity.ProductDetail ProductDetail { get; set; }

        //---------------------------------------------------------
        [Display(Name = nameof(Resources.Resource.SliderId), ResourceType = typeof(Resources.Resource))]
        public int? SliderId { get; set; }

        public Domain.Entity.Slider Slider { get; set; }
        //---------------------------------------------------------


    }
}
