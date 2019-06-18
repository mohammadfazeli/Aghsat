using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.Domain.Entity;

namespace Aghsat.ViewModel.ProductDetail
{
    public class ProductDetail_List_vm : BaseViewModel
    {
        [Display(Name = "UnitPrice", ResourceType = typeof(Resources.Resource))]
        public int UnitPrice { get; set; }
        //---------------------------------------------------------

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "PriceDate", ResourceType = typeof(Resources.Resource))]
        public DateTime PriceDate { get; set; }
        //---------------------------------------------------------

        [Display(Name = "Inventory", ResourceType = typeof(Resources.Resource))]
        public int Inventory { get; set; }
        //---------------------------------------------------------

        [Display(Name = "IsExist", ResourceType = typeof(Resources.Resource))]
        public bool IsExist { get; set; }
        //---------------------------------------------------------
        [Display(Name = "ProductName", ResourceType = typeof(Resources.Resource))]
        public int ProductName { get; set; }
    }
}
