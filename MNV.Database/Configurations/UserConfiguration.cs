using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MNV.Domain.Entities;
using System;

namespace MNV.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", schema: "dbo").HasKey(x => x.ID);

            builder.Property(e => e.ID).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(e => e.Key).HasColumnName("Key").HasDefaultValue(Guid.NewGuid());
            builder.Property(e => e.Username).HasColumnName("Username").HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.FirstName).HasColumnName("FirstName").HasMaxLength(100).IsRequired(false);
            builder.Property(e => e.LastName).HasColumnName("LastName").HasMaxLength(100).IsRequired(false);
            builder.Property(e => e.Email).HasColumnName("Email").HasMaxLength(100).IsRequired(false);
            builder.Property(e => e.CreatedByID).HasColumnName("CreatedByID").IsRequired(false);
            builder.Property(e => e.ModifiedByID).HasColumnName("ModifiedByID").IsRequired(false);
            builder.Property(e => e.DateCreated).HasColumnName("DateCreated").HasDefaultValue(DateTimeOffset.Now);
            builder.Property(e => e.DateModified).HasColumnName("DateModified").IsRequired(false);
            builder.Property(e => e.Active).HasColumnName("Active").HasDefaultValue(true);

            builder.HasIndex(x => x.Username).IsUnique(true);
            builder.HasIndex(x => x.Email).IsUnique(true);
        }
    }
}
