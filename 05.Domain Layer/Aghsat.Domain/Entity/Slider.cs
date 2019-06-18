using System.ComponentModel.DataAnnotations;

namespace Aghsat.Domain.Entity
{
    public class Slider : BaseEntity
    {
        [MaxLength(30)]
        [Required]
        public string PictureName { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public int? DisplayPriority { get; set; }

    }
}
