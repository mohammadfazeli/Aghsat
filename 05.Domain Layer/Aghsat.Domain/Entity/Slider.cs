namespace Aghsat.Domain.Entity
{
    public class Slider : BaseEntity
    {
        public string ImageName { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public int order { get; set; }

    }
}
