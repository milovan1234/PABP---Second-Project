using DAL.Models;

namespace DAL.Repositories
{
    public interface IEmployeesRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int employeeId);
        void Add(Employee employee);
        void Delete(int employeeId);
        void Edit(Employee employee);
    }
}
