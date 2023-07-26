using Data.Models;
using Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Clients
{
    public class SectorRep
    {
        private readonly IRepository<EntitySector> repo;
        public SectorRep(PhotographerContext context)
        {
            repo = new GenericRepository<EntitySector>(context);
        }

        public EntitySector Save(EntitySector instance)
        {
            try
            {
                if(instance.Id == Guid.Empty)
                    Insert(instance);
                else
                    Update(instance);
                return instance;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Insert(EntitySector instance)
        {
            instance.Date = DateTime.Now;
            repo.Add(instance);
        }

        public void Update(EntitySector instance)
        {
            repo.Update(instance);
        }

        public void Delete(EntitySector instance)
        {
            repo.Delete(instance);
        }

        public Task<List<EntitySector>> GetAll()
        {
            return repo.Query
                .Include(x => x.Type)
                .ToListAsync();
        }
        
        
    }
}
