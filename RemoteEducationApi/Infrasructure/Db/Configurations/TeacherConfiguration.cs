using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Infrastructure.Db.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(t => t.FirstName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(t => t.LastName)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasIndex(t => t.UserId)
                .IsUnique();
        }
    }
}
