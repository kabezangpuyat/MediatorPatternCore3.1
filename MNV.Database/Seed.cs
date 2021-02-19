using Microsoft.EntityFrameworkCore;
using MNV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MNV.Database
{
    public static class Seed
    {
        public static void Initialiaze(ModelBuilder builder)
        {

        }

        #region Private Method(s)
        private static void SeedRole(ModelBuilder builder)
        {
            Guid superAdminKey = Guid.Parse("2B7D30D0-8DC0-4343-9275-860E3959472E");
            Guid adminKey = Guid.Parse("80B24D7B-8873-4E04-9B91-9FB70C07AACF");
            Guid guestKey = Guid.Parse("E2A7B30A-FACE-4AEA-AE6E-AF57B2634DAA");

            //var hasher = new PasswordHasher<User>(
            //   new OptionsWrapper<PasswordHasherOptions>(
            //       new PasswordHasherOptions()
            //       {
            //           CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2
            //       })
           //);

            builder.Entity<Role>()
                .HasData(
                    new Role { ID = 1, Name = "Superadmin", Description = "Super Administrator", Active = true, Key = superAdminKey, DateCreated = DateTimeOffset.Now },
                    new Role { ID = 2, Name = "Administrator", Description = "Administrator", Active = true, Key = adminKey, DateCreated = DateTimeOffset.Now },
                    new Role { ID = 3, Name = "Superadmin", Description = "Guest", Active = true, Key = guestKey, DateCreated = DateTimeOffset.Now }
                );
        }
        private static void SeedUser(ModelBuilder builder)
        {
            Guid superAdmin = Guid.Parse("2B7D30D0-8DC0-4343-9275-860E3959472E");

            builder.Entity<User>()
                .HasData(
                    new User { ID = 1, Username = "mv160499r" }
                );
        }
        private static void SeedUserRole(ModelBuilder builder)
        {

        }

        #endregion
    }
}
