using DAL.Models;

namespace DAL.Repositories
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetAll();
    }
}
