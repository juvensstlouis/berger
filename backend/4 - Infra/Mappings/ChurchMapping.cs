using Berger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Berger.Infra.Mappings
{
    public class ChurchMapping : IEntityTypeConfiguration<Church>
    {
        public void Configure(EntityTypeBuilder<Church> builder)
        {
            builder.ToTable("Churches");
            builder.HasKey(c => c.Id);
            builder.OwnsOne(c => c.Address);
        }
    }
}
