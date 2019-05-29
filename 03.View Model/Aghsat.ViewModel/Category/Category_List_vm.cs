using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aghsat.ViewModel.Category
{
    public class Category_List_vm : BaseViewModel
    {
        [Display(Name = "Name", ResourceType = typeof(Resources.Resource))]
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }

    }
}
