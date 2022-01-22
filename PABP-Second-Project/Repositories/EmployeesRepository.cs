using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PABP_Second_Project.Models;

namespace PABP_Second_Project.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private NorthwindContext _context;
        public EmployeesRepository(NorthwindContext context)
        {
            this._context = context;
        }       

        public IEnumerable<Employee> GetAll()
        {
            return this._context.Employees.Include(x => x.ReportsToNavigation);
        }

        public Employee GetById(int employeeId)
        {
            return this._context.Employees.Include(x => x.ReportsToNavigation).Single(x => x.EmployeeId == employeeId);
        }

        public void Add(Employee employee)
        {
            this._context.Employees.Add(employee);
            this._context.SaveChanges();
        }

        public void Delete(int employeeId)
        {
            Employee? employee = this._context.Employees.SingleOrDefault(x => x.EmployeeId == employeeId);
            if (employee == null)
            {
                throw new Exception("Employee does not exist.");
            }
            this._context.Employees.Remove(employee);
            this._context.SaveChanges();
        }

        public void Edit(Employee employee)
        {
            this._context.Employees.Update(employee);
            this._context.SaveChanges();
        }
    }
}
