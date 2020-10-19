using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Db.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(t => t.FirstName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(t => t.LastName)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
