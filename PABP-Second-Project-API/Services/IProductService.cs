using DAL.Models;

namespace PABP_Second_Project_API.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int productId);
        Product UpdateProduct(int productId, Product product);
        void DeleteProduct(int productId);
    }
}
