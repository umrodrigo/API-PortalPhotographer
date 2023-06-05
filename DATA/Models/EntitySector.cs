
namespace Data.Models
{
    public class EntitySector
    {
        public Guid Id { get; set; }
        public int IdType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public virtual EntityType Type { get; set; }
        public virtual PhotoSector PhotoSector { get; set; }

    }
}
