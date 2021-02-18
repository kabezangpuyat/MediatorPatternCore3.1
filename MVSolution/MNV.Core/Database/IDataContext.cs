using Microsoft.EntityFrameworkCore;
using MNV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MNV.Core.Database
{
    public interface IDataContext : IDisposable
    {
        DbSet<User> User { get; set; }
        DbSet<Role> Role { get; set; }
        DbSet<UserRole> UserRole { get; set; }
        DbSet<RefreshToken> RefreshToken { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
