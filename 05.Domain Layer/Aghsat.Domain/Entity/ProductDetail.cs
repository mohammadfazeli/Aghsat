using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aghsat.Domain.Entity
{
    public class ProductDetail : BaseEntity
    {
        public int UnitPrice { get; set; }
        //---------------------------------------------------------
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        public DateTime PriceDate { get; set; }
        //---------------------------------------------------------
        public int Inventory { get; set; }
        //---------------------------------------------------------
        public bool IsExist { get; set; }
        //---------------------------------------------------------
        public virtual Product Product { get; set; }
        //---------------------------------------------------------
        public int ProductId { get; set; }
        //---------------------------------------------------------
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
