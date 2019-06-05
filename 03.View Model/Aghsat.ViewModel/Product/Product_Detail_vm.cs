using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.Domain.Entity;

namespace Aghsat.ViewModel.Product
{
    public class Product_Detail_vm : BaseViewModel
    {
        [Display(Name = "Name", ResourceType = typeof(Resources.Resource))]
        public string Name { get; set; }

        [Display(Name = "ProductDate", ResourceType = typeof(Resources.Resource))]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime ProductDate { get; set; }
        [Display(Name = "MainImage", ResourceType = typeof(Resources.Resource))]

        public string MainImage { get; set; }
        [Display(Name = "UnitName", ResourceType = typeof(Resources.Resource))]

        public string UnitName { get; set; }
        [Display(Name = "CategoryName", ResourceType = typeof(Resources.Resource))]

        public string CategoryName { get; set; }
    }
}
