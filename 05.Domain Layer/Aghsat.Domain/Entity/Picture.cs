using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aghsat.Domain.Entity
{
    public class Picture : BaseEntity
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }
        public int ProductDetailId { get; set; }
    }
}
