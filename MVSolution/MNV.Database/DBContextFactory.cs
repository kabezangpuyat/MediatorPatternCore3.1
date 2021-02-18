using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace MNV.Database
{
    public class DBContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            //get env
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            // Build config
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../MNV.Web"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            // Get connection string
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            var connectionString = config.GetConnectionString("WebApiConnection");
            optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("MNV.Database"));
            return new DataContext(optionsBuilder.Options);
        }
    }
}
