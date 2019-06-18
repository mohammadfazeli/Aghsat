using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.Domain.Entity;

namespace Aghsat.ViewModel.Product
{
    public class ProductDetail_Detail_vm : BaseViewModel
    {
        public int UnitPrice { get; set; }
        //---------------------------------------------------------

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime PriceDate { get; set; }
        //---------------------------------------------------------
        [Display(Name = "IsExist", ResourceType = typeof(Resources.Resource))]

        public int Inventory { get; set; }
        //---------------------------------------------------------
        [Display(Name = "IsExist", ResourceType = typeof(Resources.Resource))]

        public bool IsExist { get; set; }
        //---------------------------------------------------------
        [Display(Name = "Pictures", ResourceType = typeof(Resources.Resource))]

        public ICollection<Picture> Pictures { get; set; }
        //---------------------------------------------------------
       
    }
}
