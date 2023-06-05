
namespace Data.Models
{
    public class EntityType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Code { get; set; }
        public virtual ICollection<EntitySector> Sector { get; set; }
        
    }
}
