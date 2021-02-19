using Microsoft.EntityFrameworkCore;
using MNV.Core.Database;
using MNV.Domain.Entities;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MNV.Database
{
    public class DataContext : DbContext, IDataContext
    {

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasSequence<int>("OrderNumbers", schema: "shared")
            //    .StartsAt(1).IncrementsBy(1);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        #region IDataContext
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        } 
        #endregion
    }
}
