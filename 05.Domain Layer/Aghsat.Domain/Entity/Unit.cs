using System.Collections.Generic;

namespace Aghsat.Domain.Entity
{
    public class Unit : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
