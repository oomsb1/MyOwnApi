using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOwnAPI.Domain.Entities;

namespace MyOwnApi.DAL.Configurations
{
    public class ChauffeurConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable("Chauffeurs");
            builder.HasKey(t => t.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(c => c.Nationality)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
