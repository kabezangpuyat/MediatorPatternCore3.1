using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MNV.Domain.Entities;
using System;

namespace MNV.Database.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role", schema: "dbo").HasKey(x => x.ID);

            builder.Property(e => e.ID).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(e => e.Key).HasColumnName("Key").HasDefaultValue(Guid.NewGuid());
            builder.Property(e => e.Name).HasColumnName("Name").HasMaxLength(100);
            builder.Property(e => e.CreatedByID).HasColumnName("CreatedByID").IsRequired(false);
            builder.Property(e => e.ModifiedByID).HasColumnName("ModifiedByID").IsRequired(false);
            builder.Property(e => e.DateCreated).HasColumnName("DateCreated").HasDefaultValue(DateTimeOffset.Now);
            builder.Property(e => e.DateModified).HasColumnName("DateModified").IsRequired(false);
            builder.Property(e => e.Active).HasColumnName("Active").HasDefaultValue(true);

            builder.HasIndex(x => x.Name).IsUnique(true);
        }
    }
}
