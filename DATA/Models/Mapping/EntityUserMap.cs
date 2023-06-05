using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Models.Mapping
{
    public sealed class EntityUserMap : IEntityTypeConfiguration<EntityUser>
    {
        public void Configure(EntityTypeBuilder<EntityUser> builder)
        {
            builder.ToTable("entityUser", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(50).IsRequired();

        }

    }
}
