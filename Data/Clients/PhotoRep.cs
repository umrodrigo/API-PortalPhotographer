using Data.Models;
using Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Clients
{
    public class PhotoRep
    {
        private readonly IRepository<EntityPhoto> repo;
        //private readonly IRepository<PhotoSector> _photoSectorRep;
        public PhotoRep(PhotographerContext context)
        {
            repo = new GenericRepository<EntityPhoto>(context);
            //_photoSectorRep = new GenericRepository<PhotoSector>(context);
        }

        public EntityPhoto Save(EntityPhoto instance)
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

        public void Insert(EntityPhoto instance)
        {
            repo.Add(instance);
        }

        public void Update(EntityPhoto instance)
        {
            repo.Update(instance);
        }

        public void Delete(EntityPhoto instance)
        {
            repo.Delete(instance);
        }

        public Task<List<EntityPhoto>> GetAll()
        {
            return repo.Query.ToListAsync();
        }

        public Task<List<EntityPhoto>> GetAllBySector(Guid idSector)
        {
            return repo.Query
                .Where(x => x.PhotoSector.IdEntitySector == idSector)
                .Include(x => x.PhotoSector)
                .ThenInclude(x => x.EntitySector)
                .ToListAsync();
        }

        //private Task SaveRelatives(EntityPhoto instance)
        //{
        //    _photoSectorRep.Add(instance.PhotoSector);
        //}


    }
}
