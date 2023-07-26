
namespace Api.View
{
    public class EntitySectorView
    {
        public Guid Id { get; set; }
        public int IdType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public virtual EntityTypeView? Type { get; set; }
        public virtual PhotoSectorView? PhotoSector { get; set; }

    }
}
