using DAL.Models;

namespace DAL.Repositories
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int productId);
        void Add(Product product);
        void Delete(int productId);
        void Edit(Product product);
    }
}
