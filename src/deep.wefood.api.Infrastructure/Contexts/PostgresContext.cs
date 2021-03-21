using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace deep.wefood.api.Infrastructure.Repositories
{
    public class PostgresContext : DbContext
    {
        private IConfiguration _configuration;

        public PostgresContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql(
                    _configuration.GetConnectionString("Postgres"),
                    options => options.SetPostgresVersion(new Version(8, 1))
                )
                .LogTo(Console.WriteLine);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("public");
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }


    }
}
