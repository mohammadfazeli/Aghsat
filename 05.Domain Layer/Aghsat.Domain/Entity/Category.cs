using System.Collections.Generic;

namespace Aghsat.Domain.Entity
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
