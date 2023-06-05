
namespace Data.Models
{
    public class PhotoSector
    {
        public Guid Id { get; set; }
        public Guid IdEntityPhoto { get; set; }
        public Guid IdEntitySector { get; set; }
        public virtual EntityPhoto EntityPhoto { get; set; }
        public virtual EntitySector EntitySector { get; set; }

    }
}
