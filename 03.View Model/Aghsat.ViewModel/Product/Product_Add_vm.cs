using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.Domain.Entity;

namespace Aghsat.ViewModel.Product
{
    public class Product_Add_vm : BaseViewModel
    {

        //---------------------------------------------------------
        [Display(Name = "Name", ResourceType = typeof(Resources.Resource))]
        [Required(ErrorMessageResourceName = "ISRequired", ErrorMessageResourceType = typeof(Resources.Resource))]
        public string Name { get; set; }
        //---------------------------------------------------------
        [Display(Name = "ProductDate", ResourceType = typeof(Resources.Resource))]
        [Required(ErrorMessageResourceName = "ISRequired", ErrorMessageResourceType = typeof(Resources.Resource))]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime ProductDate { get; set; }
        //---------------------------------------------------------
        [Display(Name = "MainImage", ResourceType = typeof(Resources.Resource))]
        public string MainImage { get; set; }
        //---------------------------------------------------------
        public virtual IEnumerable<Unit> UnitDropDownList { get; set; }

        [Display(Name = "UnitId", ResourceType = typeof(Resources.Resource))]
        [Required(ErrorMessageResourceName = "ISRequired", ErrorMessageResourceType = typeof(Resources.Resource))]
        public Unit Unit { get; set; }
        public Domain.Entity.Category Category { get; set; }
        //---------------------------------------------------------
        [Display(Name = nameof(Resources.Resource.UnitId), ResourceType = typeof(Resources.Resource))]

        public int UnitId { get; set; }
        //---------------------------------------------------------
        public virtual IEnumerable<Domain.Entity.Category> CategoryDropDownList { get; set; }

        [Display(Name = "CategoryId", ResourceType = typeof(Resources.Resource))]
        [Required(ErrorMessageResourceName = "ISRequired", ErrorMessageResourceType = typeof(Resources.Resource))]

        public int CategoryId { get; set; }
        //---------------------------------------------------------
        public virtual ICollection<Aghsat.Domain.Entity.ProductDetail> ProductDetails { get; set; }
    }
}
