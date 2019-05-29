using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.Domain.Entity;

namespace Aghsat.ViewModel.Product
{
    public class Product_List_vm : BaseViewModel
    {
        public string Name { get; set; }
        public DateTime ProductDate { get; set; }
        public string MainImage { get; set; }
        public string UnitName { get; set; }
        //public string ParentCategoryName { get; set; }
        public string CategoryName { get; set; }
    }
}
