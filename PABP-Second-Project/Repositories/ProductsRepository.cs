using Microsoft.EntityFrameworkCore;
using PABP_Second_Project.Models;

namespace PABP_Second_Project.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private NorthwindContext _context;
        public ProductsRepository(NorthwindContext context)
        {
            this._context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return this._context.Products.Include(x => x.Category).Include(x => x.Supplier);
        }
    }
}
