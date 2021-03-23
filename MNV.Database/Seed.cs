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
            SeedRole(builder);
            SeedUser(builder);
            SeedUserRole(builder);
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
                    new Role { ID = 3, Name = "Guest", Description = "Guest", Active = true, Key = guestKey, DateCreated = DateTimeOffset.Now }
                );
        }
        private static void SeedUser(ModelBuilder builder)
        {
            Guid key = Guid.Parse("2B7D30D0-8DC0-4343-9275-860E3959472E");
            Guid key2 = Guid.Parse("80B24D7B-8873-4E04-9B91-9FB70C07AACF");
            //NOTE: Password == pasok12345
            builder.Entity<User>()
                .HasData(
                    new User { ID = 1, Username = "mcnielv@gmail.com", Email = "mcnielv@gmail.com", Password = "Jaemp2W0c4pSRQ8SMICEvg==", FirstName = "McNiel", LastName = "Viray", MiddleName = "N", Key = key, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now},
                    new User { ID = 2, Username = "mcniel.viray@gmail.com", Email = "mcniel.viray@gmail.com", Password = "Jaemp2W0c4pSRQ8SMICEvg==", FirstName = "McNiel", LastName = "Viray II", MiddleName = "N", Key = key2, Active = true, CreatedByID = 1, DateCreated = DateTimeOffset.Now }
                );
        }
        private static void SeedUserRole(ModelBuilder builder)
        {
            Guid key = Guid.Parse("2B7D30D0-8DC0-4343-9275-860E3959472E");
            Guid key2 = Guid.Parse("80B24D7B-8873-4E04-9B91-9FB70C07AACF");

            builder.Entity<UserRole>()
                .HasData(
                    new UserRole { ID = 1, Key = key, UserID = 1, RoleID = 1, Active = true, DateCreated = DateTimeOffset.Now },
                    new UserRole { ID = 2, Key = key2,  UserID = 2, RoleID = 3, Active = true, DateCreated = DateTimeOffset.Now }
                );
        }

        #endregion
    }
}
