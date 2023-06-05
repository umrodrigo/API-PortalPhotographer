using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Models.Mapping
{
    public sealed class PhotoSectorMap : IEntityTypeConfiguration<PhotoSector>
    {
        public void Configure(EntityTypeBuilder<PhotoSector> builder)
        {
            builder.ToTable("photoSector", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdEntityPhoto).IsRequired();
            builder.Property(x => x.IdEntitySector).IsRequired();

            builder
                .HasOne(one => one.EntityPhoto)
                .WithOne(one => one.PhotoSector)
                .HasForeignKey<PhotoSector>(fk => fk.IdEntityPhoto);

            builder
                .HasOne(one => one.EntitySector)
                .WithOne(one => one.PhotoSector)
                .HasForeignKey<PhotoSector>(fk => fk.IdEntitySector);
        }

    }
}
