using System;
using System.Collections.Generic;

namespace Aghsat.Domain.Entity
{
    public class ProductDetail : BaseEntity
    {
        public int UnitPrice { get; set; }
        public DateTime PriceDate { get; set; }
        public int Inventory { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
