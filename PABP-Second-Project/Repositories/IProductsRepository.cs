using PABP_Second_Project.Models;

namespace PABP_Second_Project.Repositories
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetAll();
    }
}
