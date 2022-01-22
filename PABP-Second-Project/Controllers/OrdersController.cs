using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL.Models;
using DAL.Repositories;

namespace PABP_Second_Project.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IEmployeesRepository _employeesRepository;
        private readonly ICustomersRepository _customersRepository;
        private readonly IShippersRepository _shippersRepository;

        public OrdersController(IOrdersRepository ordersRepository,
            IEmployeesRepository employeesRepository,
            ICustomersRepository customersRepository,
            IShippersRepository shippersRepository)
        {
            this._ordersRepository = ordersRepository;
            this._employeesRepository = employeesRepository;
            this._customersRepository = customersRepository;
            this._shippersRepository = shippersRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View(this._ordersRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(this._customersRepository.GetAll(), "CustomerId", "CustomerId");
            ViewData["EmployeeId"] = new SelectList(this._employeesRepository.GetAll(), "EmployeeId", "FirstName");
            ViewData["ShipVia"] = new SelectList(this._shippersRepository.GetAll(), "ShipperId", "CompanyName");

            return View();
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            Order order = this._ordersRepository.GetById(id);

            ViewData["CustomerId"] = new SelectList(this._customersRepository.GetAll(), "CustomerId", "CustomerId");
            ViewData["EmployeeId"] = new SelectList(this._employeesRepository.GetAll(), "EmployeeId", "FirstName");
            ViewData["ShipVia"] = new SelectList(this._shippersRepository.GetAll(), "ShipperId", "CompanyName");

            return View(order);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromForm]Order order)
        {            
            if (ModelState.IsValid)
            {
                this._ordersRepository.Add(order);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteOrder([FromForm] int orderId)
        {
            this._ordersRepository.Delete(orderId);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult EditOrder([FromForm] Order order)
        {
            if (ModelState.IsValid)
            {
                this._ordersRepository.Edit(order);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
