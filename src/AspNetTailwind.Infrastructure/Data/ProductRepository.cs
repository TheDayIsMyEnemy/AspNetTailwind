using AspNetTailwind.ApplicationCore.Interfaces;
using AspNetTailwind.ApplicationCore.Models;

namespace AspNetTailwind.Infrastructure.Data
{
    public class FilterRepository : Repository<Product>, IProductRepository
    {
        public FilterRepository(AppDbContext context)
            : base(context) { }
    }
}
