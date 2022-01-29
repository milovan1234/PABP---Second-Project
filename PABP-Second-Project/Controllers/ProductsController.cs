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
        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly ICustomersRepository _customersRepository;

        public ProductsController(IProductsRepository productsRepository,
            ISuppliersRepository suppliersRepository,
            ICategoriesRepository categoriesRepository,
            IOrdersRepository ordersRepository,
            IOrderDetailsRepository orderDetailsRepository,
            ICustomersRepository customersRepository)
        {
            this._productsRepository = productsRepository;
            this._suppliersRepository = suppliersRepository;
            this._categoriesRepository = categoriesRepository;
            this._ordersRepository = ordersRepository;
            this._orderDetailsRepository = orderDetailsRepository;
            this._customersRepository = customersRepository;
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

        [HttpGet]
        public IActionResult ProductsForOrderByOrder(int orderId)
        {
            Order order = _ordersRepository.GetById(orderId);
            List<OrderDetail> orderDetails = this._orderDetailsRepository.GetAll().Where(x => x.OrderId == orderId).ToList();
            string? customerId = order.CustomerId;
            ViewData["CustomerId"] = new SelectList(this._customersRepository.GetAll(), "CustomerId", "CompanyName", customerId);
            ViewData["OrderId"] = new SelectList(this._ordersRepository.GetAll().Where(x => x.CustomerId == customerId), "OrderId", "OrderId", orderId);

            List<Product> products = new List<Product>();

            foreach (OrderDetail orderDetail in orderDetails)
            {
                products.Add(orderDetail.Product);
            }

            return View(nameof(ProductsForOrder), products);
        }

        [HttpGet]
        public IActionResult ProductsForOrder()
        {
            ViewData["CustomerId"] = new SelectList(this._customersRepository.GetAll(), "CustomerId", "CompanyName");
            ViewData["OrderId"] = new SelectList(new List<Order>(), "OrderId", "OrderId");
            
            return View(new List<Product>());
        }

        [HttpGet]
        public IActionResult ProductsForOrderByCustomer(string customerId)
        {
            ViewData["CustomerId"] = new SelectList(this._customersRepository.GetAll(), "CustomerId", "CompanyName", customerId);
            ViewData["OrderId"] = new SelectList(this._ordersRepository.GetAll().Where(x => x.CustomerId == customerId), "OrderId", "OrderId");
            
            return View(nameof(ProductsForOrder), new List<Product>());
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
