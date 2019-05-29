using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.Domain.Entity;

namespace Aghsat.ViewModel.Category
{
    public class Category_Add_vm : BaseViewModel
    {
        //[Required(ErrorMessage = "نام دسته بندی را وارد کنید")]
        [Required(ErrorMessageResourceName = "ISRequired", ErrorMessageResourceType = typeof(Resources.Resource))]
        [MaxLength(10, ErrorMessage = "حداکثر 10 کاراکتر")]
        [Display(Name = "Name", ResourceType = typeof(Resources.Resource))]
        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }
        public virtual Domain.Entity.Category ParentCategory { get; set; }
        public virtual IEnumerable<Domain.Entity.Category> SubCategories { get; set; }
        public virtual IEnumerable<Domain.Entity.Product> Products { get; set; }
    }
}
