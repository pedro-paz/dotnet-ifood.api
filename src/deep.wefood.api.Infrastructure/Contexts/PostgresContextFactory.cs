using System;
using System.IO;
using deep.wefood.api.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace deep.wefood.api.Infrastructure.Contexts
{
    public class PostgresContextFactory : IDesignTimeDbContextFactory<PostgresContext>
    {
        public PostgresContext CreateDbContext(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).ToString())
                .AddJsonFile("deep.wefood.api.Presentation/appsettings.json")
                .Build();

            return new PostgresContext(configuration);
        }
    }
}