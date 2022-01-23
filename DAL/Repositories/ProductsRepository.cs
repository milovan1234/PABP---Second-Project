using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL.Repositories
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

        public Product GetById(int productId)
        {
            return this._context.Products.Include(x => x.Category).Include(x => x.Supplier).Single(x => x.ProductId == productId);
        }

        public void Add(Product product)
        {
            this._context.Products.Add(product);
            this._context.SaveChanges();
        }

        public void Delete(int productId)
        {
            Product? product = this._context.Products.SingleOrDefault(x => x.ProductId == productId);
            if (product == null)
            {
                throw new Exception("Product does not exist.");
            }
            this._context.Products.Remove(product);
            this._context.SaveChanges();
        }

        public void Edit(Product product)
        {
            this._context.Products.Update(product);
            this._context.SaveChanges();
        }
    }
}
