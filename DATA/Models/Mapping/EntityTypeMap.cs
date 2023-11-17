using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Models.Mapping
{
    public sealed class EntityTypeMap : IEntityTypeConfiguration<EntityType>
    {
        public void Configure(EntityTypeBuilder<EntityType> builder)
        {
            builder.ToTable("entityType", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Code);

            builder
                .HasMany(many => many.EntitySector)
                .WithOne(one => one.Type)
                .HasForeignKey(one => one.IdType);
        }

    }
}
