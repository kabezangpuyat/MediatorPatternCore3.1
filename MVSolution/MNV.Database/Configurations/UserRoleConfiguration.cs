using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MNV.Domain.Entities;
using System;

namespace MNV.Database.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole", schema: "dbo").HasKey(x => x.ID);

            builder.Property(e => e.ID).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(e => e.Key).HasColumnName("Key").HasDefaultValue(Guid.NewGuid());
            builder.Property(e => e.UserID).HasColumnName("UserID").IsRequired(true);
            builder.Property(e => e.RoleID).HasColumnName("RoleID").IsRequired(true);
            builder.Property(e => e.CreatedByID).HasColumnName("CreatedByID").IsRequired(false);
            builder.Property(e => e.ModifiedByID).HasColumnName("ModifiedByID").IsRequired(false);
            builder.Property(e => e.DateCreated).HasColumnName("DateCreated").HasDefaultValue(DateTimeOffset.Now);
            builder.Property(e => e.DateModified).HasColumnName("DateModified").IsRequired(false);
            builder.Property(e => e.Active).HasColumnName("Active").HasDefaultValue(true);

            builder.HasOne<Role>(x => x.Role)
                .WithMany()
                .HasForeignKey(x => x.RoleID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder.HasOne<User>(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);
        }
    }
}
