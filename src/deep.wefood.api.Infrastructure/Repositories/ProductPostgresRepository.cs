using System.Linq;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;
using Microsoft.EntityFrameworkCore;

namespace deep.wefood.api.Infrastructure.Repositories
{
    public class ProductPostgresRepository : PostgresRepository<Product>, IProductRepository
    {
        public ProductPostgresRepository(PostgresContext context) : base(context)
        {

        }

        public Product FindProductDetail(string guidProduct)
        {
            var product = _context.Set<Product>().Where(x => x.Guid == guidProduct)
                .Include(x => x.ComplementGroups)
                .Include(x => x.ComplementGroups.Select(y => y.Complements))
                .FirstOrDefault();

            return product;
        }
    }
}