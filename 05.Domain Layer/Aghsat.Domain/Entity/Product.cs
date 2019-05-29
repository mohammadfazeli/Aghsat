using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Aghsat.Domain.Entity
{
    public class Product : BaseEntity
    {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        [Column(TypeName ="date")]
        public DateTime ProductDate { get; set; }
        public string MainImage { get; set; }
        public virtual Unit Unit { get; set; }
        public int UnitId { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<ProductDetail>  ProductDetails { get; set; }
    }
}
