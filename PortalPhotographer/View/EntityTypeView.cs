
namespace Api.View
{
    public class EntityTypeView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Code { get; set; }
        public virtual ICollection<EntitySectorView>? Sector { get; set; }
        
    }
}
