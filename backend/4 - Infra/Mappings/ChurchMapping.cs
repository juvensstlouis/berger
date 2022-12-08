using Berger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Berger.Infra.Mappings
{
    public class ChurchMapping : IEntityTypeConfiguration<Church>
    {
        public void Configure(EntityTypeBuilder<Church> builder)
        {
            builder.ToTable("Church");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.UserId).IsRequired();

            builder.HasOne(x => x.UserLoggedIn)
                   .WithMany(x => x.Churchs)
                   .HasForeignKey(x => x.UserId);

        }
    }
}
