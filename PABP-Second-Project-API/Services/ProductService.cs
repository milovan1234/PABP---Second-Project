using DAL.Models;
using DAL.Repositories;

namespace PABP_Second_Project_API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductsRepository _productsRepository;
        public ProductService(IProductsRepository productsRepository)
        {
            this._productsRepository = productsRepository;
        }

        public IEnumerable<Product> GetProducts()
        {
            return this._productsRepository.GetAll();
        }

        public Product GetProductById(int productId)
        {
            return this._productsRepository.GetById(productId);
        }
        public Product UpdateProduct(int productId, Product product)
        {
            if (product.ProductName == "")
            {
                throw new Exception("The product name must be filled in.");
            }

            this._productsRepository.Edit(product);

            return this._productsRepository.GetById(productId);
        }

        public void DeleteProduct(int productId)
        {
            Product product = this.GetProductById(productId);
            if (product == null)
            {
                throw new Exception("The product with given product Id does not exist.");
            }

            this._productsRepository.Delete(productId);
        }
    }
}
