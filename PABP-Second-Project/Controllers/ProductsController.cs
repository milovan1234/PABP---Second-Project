using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL.Repositories;
using DAL.Models;

namespace PABP_Second_Project.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ISuppliersRepository _suppliersRepository;
        private readonly ICategoriesRepository _categoriesRepository;

        public ProductsController(IProductsRepository productsRepository,
            ISuppliersRepository suppliersRepository,
            ICategoriesRepository categoriesRepository)
        {
            this._productsRepository = productsRepository;
            this._suppliersRepository = suppliersRepository;
            this._categoriesRepository = categoriesRepository;
        }

        public IActionResult Index()
        {
            ViewData["SupplierId"] = new SelectList(this._suppliersRepository.GetAll(), "SupplierId", "CompanyName");
            
            return View(this._productsRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create(int supplierId)
        {
            ViewData["CategoryId"] = new SelectList(this._categoriesRepository.GetAll(), "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(this._suppliersRepository.GetAll().Where(x => x.SupplierId == supplierId), "SupplierId", "CompanyName");
            
            return View();
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            Product product = this._productsRepository.GetById(id);
            ViewData["CategoryId"] = new SelectList(this._categoriesRepository.GetAll(), "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(this._suppliersRepository.GetAll(), "SupplierId", "CompanyName", product.SupplierId);

            return View(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromForm]Product product)
        {
            if (ModelState.IsValid)
            {
                this._productsRepository.Add(product);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteProduct([FromForm] int productId)
        {
            this._productsRepository.Delete(productId);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult EditProduct([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                this._productsRepository.Edit(product);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
