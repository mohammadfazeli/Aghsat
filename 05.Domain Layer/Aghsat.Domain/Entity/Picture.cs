using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aghsat.Domain.Entity
{
    public class Picture : BaseEntity
    {
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(20)]
        public string PictureName { get; set; }
        //---------------------------------------------------------
        public int? DisplayPriority { get; set; }
        //---------------------------------------------------------
        [MaxLength(50)]
        public string ShortDescription { get; set; }
        //---------------------------------------------------------
        public virtual ProductDetail ProductDetail { get; set; }
        public int? ProductDetailId { get; set; }
    }
}
