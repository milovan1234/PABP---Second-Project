using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL.Repositories;

namespace PABP_Second_Project.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ISuppliersRepository _suppliersRepository;

        public ProductsController(IProductsRepository productsRepository,
            ISuppliersRepository suppliersRepository)
        {
            this._productsRepository = productsRepository;
            this._suppliersRepository = suppliersRepository;
        }

        public IActionResult Index()
        {
            ViewData["SupplierId"] = new SelectList(this._suppliersRepository.GetAll(), "SupplierId", "CompanyName");
            return View(this._productsRepository.GetAll());
        }
    }
}
