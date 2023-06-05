using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Models.Mapping
{
    public sealed class EntityPhotoMap : IEntityTypeConfiguration<EntityPhoto>
    {
        public void Configure(EntityTypeBuilder<EntityPhoto> builder)
        {
            builder.ToTable("entityPhoto", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Url).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.Order);
            builder.Property(x => x.CreatedAt);

        }

    }
}
