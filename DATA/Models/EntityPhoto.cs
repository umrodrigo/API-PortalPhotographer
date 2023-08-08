
namespace Data.Models
{
    public class EntityPhoto
    {
        public Guid Id { get; set; }
        public string? Url { get; set; }
        public string? Description { get; set; }
        public int? Order { get; set; }
        public DateTime? CreatedAt { get; set; }
        public virtual PhotoSector? PhotoSector { get; set; }
    }
}
