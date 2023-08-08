using Api.Models;

namespace Api.View
{
    public class EntityPhotoView
    {
        public EntityPhotoView() 
        { 
            CreatedAt = DateTime.Now;
        }

        public Guid? Id { get; set; }
        public string? Url { get; set; }
        public string? Description { get; set; }
        public int? Order { get; set; }
        public DateTime? CreatedAt { get; set; }
        public virtual PhotoSectorView? PhotoSector { get; set; }
        public virtual FileData? FileData { get; set; }
        
    }
}
