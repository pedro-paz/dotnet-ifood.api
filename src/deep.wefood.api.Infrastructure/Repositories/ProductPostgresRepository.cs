using System.Collections.Generic;
using System.Linq;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;
using Microsoft.EntityFrameworkCore;

namespace deep.wefood.api.Infrastructure.Repositories
{
    public class ProductPostgresRepository : PostgresRepository<ProductDetail>, IProductRepository
    {
        public ProductPostgresRepository(PostgresContext context) : base(context)
        {

        }

        public ProductDetail FindProductDetail(string guidProduct)
        {
            var product = _context.Set<ProductDetail>().Where(x => x.Guid == guidProduct)
                .Include(x => x.ComplementGroups)
                .ThenInclude(x => x.Complements)
                .FirstOrDefault();

            return product;
        }

    }
}