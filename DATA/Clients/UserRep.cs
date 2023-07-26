using Data.Models;
using Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Clients
{
    public class UserRep
    {
        private readonly IRepository<EntityUser> repo;
        public UserRep(PhotographerContext context)
        {
            repo = new GenericRepository<EntityUser>(context);
        }

        public EntityUser Save(EntityUser instance)
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

        public void Insert(EntityUser instance)
        {
            //instance.CreatedAt = DateTime.Now;
            //instance.UpdateAt = instance.CreatedAt;
            repo.Add(instance);
        }

        public void Update(EntityUser instance)
        {
            //instance.UpdateAt = DateTime.Now;
            repo.Update(instance);
        }
        public void Delete(EntityUser instance)
        {
            repo.Delete(instance);
        }
        public Task<List<EntityUser>> GetAll()
        {
            return repo.Query.ToListAsync();
        }
        public Task<List<EntityUser>> Get(int pageIndex, int pageSize, string search)
        {
            var qr = repo.Query;

            if (!String.IsNullOrEmpty(search))
                qr = qr.Where(z => EF.Functions.Like(z.Name, $"%{search}%"));

            return qr
                .OrderBy(z => z.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        
        public async Task<Guid> Authenticate(string username, string password)
        {
            try
            {
                var user = await repo.FirstOrDefaultAsync(z => z.Email == username && z.Password == password);
                return user.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EntityUser> GetById(Guid id)
        {
            var user = await repo.FirstOrDefaultAsync(x => x.Id == id);

            return user;            
        }
    }
}
