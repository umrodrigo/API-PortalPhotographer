using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Models.Mapping
{
    public sealed class EntitySectorMap : IEntityTypeConfiguration<EntitySector>
    {
        public void Configure(EntityTypeBuilder<EntitySector> builder)
        {
            builder.ToTable("entitySector", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdType).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(255);
            builder.Property(x => x.Description);
            builder.Property(x => x.Date);

        }

    }
}
