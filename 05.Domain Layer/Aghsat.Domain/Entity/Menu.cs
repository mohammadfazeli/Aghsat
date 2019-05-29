using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aghsat.Domain.Entity
{
    public class Menu : BaseEntity
    {
        public string MenuName { get; set; }
        public string IconMenu { get; set; }
        public virtual Menu ParentMenu { get; set; }
        public int? ParentMenuId { get; set; }
        public virtual ICollection<Menu> SubCategories { get; set; }
    }
}
