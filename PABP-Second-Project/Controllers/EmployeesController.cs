using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PABP_Second_Project.Models;
using PABP_Second_Project.Repositories;

namespace PABP_Second_Project.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesController(IEmployeesRepository employeesRepository)
        {
            this._employeesRepository = employeesRepository;
        }        

        [HttpGet]
        public IActionResult Index()
        {
            return View(this._employeesRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ReportsTo"] = new SelectList(this._employeesRepository.GetAll(), "EmployeeId", "FirstName");
            
            return View();
        }

        [HttpGet]
        public IActionResult Edit([FromRoute]int id)
        {
            Employee employee = this._employeesRepository.GetById(id);
            ViewData["ReportsTo"] = new SelectList(this._employeesRepository.GetAll(), "EmployeeId", "FirstName");

            return View(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromForm]Employee employee)
        {
            if (ModelState.IsValid)
            {
                this._employeesRepository.Add(employee);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteEmployee([FromForm]int employeeId)
        {
            this._employeesRepository.Delete(employeeId);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult EditEmployee([FromForm]Employee employee)
        {
            if (ModelState.IsValid)
            {
                this._employeesRepository.Edit(employee);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
