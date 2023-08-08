
namespace Api.View
{
    public class PhotoSectorView
    {
        public Guid Id { get; set; }
        public Guid IdEntityPhoto { get; set; }
        public Guid IdEntitySector { get; set; }
        public virtual EntityPhotoView? EntityPhoto { get; set; }
        public virtual EntitySectorView? EntitySector { get; set; }

    }
}
