using Berger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Berger.Infra.Mappings
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.UserId).IsRequired();

            builder.Property(c => c.Code).IsRequired();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Address).IsRequired();
            builder.Property(c => c.PhoneNumber).IsRequired();
            builder.Property(c => c.ChurchId).IsRequired();

            builder.HasOne(x => x.UserLoggedIn)
                   .WithMany(x => x.People)
                   .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Church)
                   .WithMany(x => x.Members)
                   .HasForeignKey(x => x.ChurchId);
        }
    }
}