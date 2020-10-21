using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Db.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.FirstName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(s => s.LastName)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasIndex(s => s.UserId)
                .IsUnique();
        }
    }
}
