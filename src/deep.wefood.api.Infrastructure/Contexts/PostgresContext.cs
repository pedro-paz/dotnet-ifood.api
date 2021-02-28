using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

// rodar apenas uma vez: dotnet tool install --global dotnet-ef
// ir para projeto principal
// rodar para migrar: dotnet-ef migrations add initial


namespace deep.wefood.api.Infrastructure.Repositories
{
    public class PostgresContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseNpgsql(
                "Server=localhost;Port=5432;Database=restaurant_manager;User Id=postgres;Password=Paz030993;",
                options => options.SetPostgresVersion(new Version(8, 1))
            );
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("public");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }


    }
}
