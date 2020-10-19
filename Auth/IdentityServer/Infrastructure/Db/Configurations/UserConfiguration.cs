using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Db.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(t => t.FirstName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(t => t.LastName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(t => t.Password)
                .IsRequired();

            builder.Property(t => t.UserName)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(t => t.Email)
                .IsRequired();

            builder.Property(t => t.Role)
                .IsRequired();
        }
    }
}
