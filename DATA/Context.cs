using Data.Models;
using Data.Models.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PhotographerContext : DbContext
    {
        public PhotographerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EntityUser> EntityUser { get; set; }
        public DbSet<EntityType> EntityType { get; set; }
        public DbSet<EntityPhoto> EntityPhoto { get; set; }
        public DbSet<EntitySector> EntitySector { get; set; }
        public DbSet<PhotoSector> PhotoSector { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new EntityUserMap())
                .ApplyConfiguration(new EntityTypeMap())
                .ApplyConfiguration(new EntityPhotoMap())
                .ApplyConfiguration(new EntitySectorMap())
                .ApplyConfiguration(new PhotoSectorMap())
                ;
        }
    }
}