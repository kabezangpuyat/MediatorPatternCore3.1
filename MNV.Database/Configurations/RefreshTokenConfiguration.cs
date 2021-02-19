using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MNV.Domain.Entities;

namespace MNV.Database.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("RefreshToken", schema: "dbo").HasKey(x => x.ID);

            builder.Property(e => e.ID).HasColumnName("ID").ValueGeneratedOnAdd();

            builder.HasOne<User>(x => x.User)
                .WithMany(x => x.RefreshTokens)
                .HasForeignKey(x => x.UserID);
        }
    }
}
